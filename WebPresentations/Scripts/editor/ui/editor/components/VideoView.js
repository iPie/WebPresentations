
/*
@author Tantaman
*/


(function() {

  define(["./ComponentView"], function(ComponentView) {
    return ComponentView.extend({
      className: "component videoView",
      initialize: function() {
        return ComponentView.prototype.initialize.apply(this, arguments);
      },
      _finishRender: function($video) {
        this.origSize = {
          width: $video[0].videoWidth,
          height: $video[0].videoHeight
        };
        return this._setUpdatedTransform();
      },
      render: function() {
        var $video,
          _this = this;
        ComponentView.prototype.render.call(this);
        $video = $("<video controls></video>");
        $video.append("<source preload='metadata' src='" + (this.model.get("src")) + "' type='" + (this.model.get("videoType")) + "' />");
        $video.bind("loadedmetadata", function() {
          return _this._finishRender($video);
        });
        this.$el.find(".content").append($video);
        return this.$el;
      }
    });
  });

}).call(this);
