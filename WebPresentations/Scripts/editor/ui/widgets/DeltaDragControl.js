
/*
@author Matt Crinklaw-Vogt
*/


(function() {

  define(function() {
    var DragControl, events;
    events = ["mousedown", "mousemove", "mouseup"];
    return DragControl = (function() {

      DragControl.name = 'DragControl';

      function DragControl($el, stopProp) {
        this.$el = $el;
        this.stopProp = stopProp;
        this.dragging = false;
        this._mousemove = this.mousemove.bind(this);
        this._mouseup = this.mouseup.bind(this);
        this._mouseout = this._mouseup;
        $(document).bind("mousemove", this._mousemove);
        $(document).bind("mouseup", this._mouseup);
        this.$el.bind("mousedown", this.mousedown.bind(this));
        this.$el.bind("mouseup", this._mouseup);
      }

      DragControl.prototype.dispose = function() {
        $(document).unbind("mousemove", this._mousemove);
        return $(document).unbind("mouseup", this._mouseup);
      };

      DragControl.prototype.mousedown = function(e) {
        this.dragging = true;
        this._startPos = {
          x: e.pageX,
          y: e.pageY
        };
        this.$el.trigger("deltadragStart", {
          x: e.pageX,
          y: e.pageY
        });
        if (this.stopProp) {
          return e.stopPropagation();
        }
      };

      DragControl.prototype.mousemove = function(e) {
        var dx, dy;
        if (this.dragging) {
          dx = e.pageX - this._startPos.x;
          dy = e.pageY - this._startPos.y;
          this.$el.trigger("deltadrag", [
            {
              dx: dx,
              dy: dy,
              x: e.pageX,
              y: e.pageY
            }
          ]);
          if (this.stopProp) {
            return e.stopPropagation();
          }
        }
      };

      DragControl.prototype.mouseup = function(e) {
        this.dragging = false;
        return true;
      };

      return DragControl;

    })();
  });

}).call(this);
