
/*
@author Tantaman
*/


(function() {

  define(["./ComponentView"], function(ComponentView) {
    return ComponentView.extend({
      className: "component webFrameView",
      initialize: function() {
        return ComponentView.prototype.initialize.apply(this, arguments);
      },
      render: function() {
        var $frame;
        ComponentView.prototype.render.call(this);
        $frame = $("<iframe src=" + (this.model.get('src')) + "></iframe>");
        this.$el.find(".content").append($frame);
        return this.$el;
      }
    });
  });

}).call(this);
