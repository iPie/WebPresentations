
/*
@author Matt Crinklaw-Vogt
*/


(function() {

  define(["common/Throttler", "./TextboxDrawer", "./ImageModelDrawer"], function(Throttler, TextBoxDrawer, ImageModelDrawer) {
    var SlideDrawer;
    return SlideDrawer = (function() {

      SlideDrawer.name = 'SlideDrawer';

      function SlideDrawer(model, g2d) {
        var key, value, _ref;
        this.model = model;
        this.g2d = g2d;
        this.model.on("contentsChanged", this.repaint, this);
        this.size = {
          width: this.g2d.canvas.width,
          height: this.g2d.canvas.height
        };
        this.throttler = new Throttler(600, this);
        this.scale = {
          x: this.size.width / slideConfig.size.width,
          y: this.size.height / slideConfig.size.height
        };
        this.drawers = {
          TextBox: new TextBoxDrawer(this.g2d),
          ImageModel: new ImageModelDrawer(this.g2d)
        };
        _ref = this.drawers;
        for (key in _ref) {
          value = _ref[key];
          value.scale = this.scale;
        }
      }

      SlideDrawer.prototype.resized = function(newSize) {
        var key, value, _ref;
        this.size = newSize;
        this.scale = this.size.width / slideConfig.size.width;
        _ref = this.drawers;
        for (key in _ref) {
          value = _ref[key];
          value.scale = this.scale;
        }
        return this.repaint();
      };

      SlideDrawer.prototype.repaint = function() {
        return this.throttler.submit(this.paint, {
          rejectionPolicy: "runLast"
        });
      };

      SlideDrawer.prototype.paint = function() {
        var components,
          _this = this;
        this.g2d.clearRect(0, 0, this.size.width, this.size.height);
        components = this.model.get("components");
        return components.forEach(function(component) {
          var drawer, type;
          type = component.get("type");
          drawer = _this.drawers[type];
          if (drawer != null) {
            _this.g2d.save();
            drawer.paint(component);
            return _this.g2d.restore();
          }
        });
      };

      SlideDrawer.prototype.dispose = function() {
        return this.model.off(null, null, this);
      };

      return SlideDrawer;

    })();
  });

}).call(this);
