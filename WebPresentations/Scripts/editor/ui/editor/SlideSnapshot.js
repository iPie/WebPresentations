
/*
@author Matt Crinklaw-Vogt
*/


(function() {

  define(["vendor/amd/backbone", "./Templates", "./raster/SlideDrawer"], function(Backbone, Templates, SlideDrawer) {
    return Backbone.View.extend({
      className: "slideSnapshot",
      events: {
        "click": "clicked",
        "click .removeBtn": "removeClicked"
      },
      initialize: function() {
        this.model.on("change:active", this._activated, this);
        this.model.on("dispose", this._modelDisposed, this);
        return this.options.deck.on("change:background", this._updateBG, this);
      },
      clicked: function() {
        this.model.set("selected", true);
        return this.model.set("active", true);
      },
      removeClicked: function(e) {
        this.trigger("removeClicked", this);
        return e.stopPropagation();
      },
      remove: function() {
        this.slideDrawer.dispose();
        this.off();
        this.$el.data("jsView", null);
        this.model.off(null, null, this);
        this.options.deck.off(null, null, this);
        return Backbone.View.prototype.remove.apply(this, arguments);
      },
      _activated: function(model, value) {
        if (value) {
          return this.$el.addClass("active");
        } else {
          return this.$el.removeClass("active");
        }
      },
      _modelDisposed: function() {
        this.model.off(null, null, this);
        return this.remove();
      },
      _updateBG: function() {
        var bg;
        bg = this.options.deck.get("background");
        console.log("BG UPDATED");
        if (bg != null) {
          this.$el.css("background-image", bg.styles[0]);
          return this.$el.css("background-image", bg.styles[1]);
        }
      },
      render: function() {
        var g2d,
          _this = this;
        if (this.slideDrawer != null) {
          this.slideDrawer.dispose();
        }
        this.$el.html(Templates.SlideSnapshot(this.model.attributes));
        g2d = this.$el.find("canvas")[0].getContext("2d");
        this.slideDrawer = new SlideDrawer(this.model, g2d);
        setTimeout(function() {
          return _this.slideDrawer.repaint();
        }, 0);
        if (this.model.get("active")) {
          this.$el.addClass("active");
        }
        this.$el.data("jsView", this);
        this._updateBG();
        return this.$el;
      }
    });
  });

}).call(this);
