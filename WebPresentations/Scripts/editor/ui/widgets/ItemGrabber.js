
/*
@author Matt Crinklaw-Vogt
*/


(function() {

  define(["vendor/amd/backbone", "./Templates", "common/Throttler"], function(Backbone, Templates, Throttler) {
    return Backbone.View.extend({
      className: "itemGrabber modal",
      events: {
        "click .ok": "okClicked",
        "keyup input[name='itemUrl']": "urlChanged",
        "paste input[name='itemUrl']": "urlChanged",
        "hidden": "hidden"
      },
      initialize: function() {
        return this.throttler = new Throttler(200, this);
      },
      show: function(cb) {
        this.cb = cb;
        return this.$el.modal('show');
      },
      okClicked: function() {
        if (!this.$el.find(".ok").hasClass("disabled")) {
          this.cb(this.src);
          return this.$el.modal('hide');
        }
      },
      hidden: function() {
        if (this.$input != null) {
          return this.$input.val("");
        }
      },
      urlChanged: function(e) {
        if (e.which === 13) {
          this.src = this.$input.val();
          return this.okClicked();
        } else {
          return this.throttler.submit(this.loadItem, {
            rejectionPolicy: "runLast"
          });
        }
      },
      loadItem: function() {
        this.item.src = this.$input.val();
        return this.src = this.item.src;
      },
      _itemLoadError: function() {
        this.$el.find(".ok").addClass("disabled");
        return this.$el.find(".alert").removeClass("disp-none");
      },
      _itemLoaded: function() {
        this.$el.find(".ok").removeClass("disabled");
        return this.$el.find(".alert").addClass("disp-none");
      },
      render: function() {
        var _this = this;
        this.$el.html(Templates.ItemGrabber(this.options));
        this.$el.modal();
        this.$el.modal("hide");
        this.item = this.$el.find(this.options.tag)[0];
        if (this.options.tag === "video") {
          this.$el.find(".modal-body").prepend("<div class='alert alert-success'>Supports <strong>mp4, webm</strong>.<br/>Try out: http://clips.vorwaerts-gmbh.de/VfE_html5.mp4 <br/>or: http://media.w3.org/2010/05/sintel/trailer.mp4</div>");
        }
        if (!this.options.ignoreErrors) {
          this.item.onerror = function() {
            return _this._itemLoadError();
          };
          this.item.onload = function() {
            return _this._itemLoaded();
          };
        }
        this.$input = this.$el.find("input[name='itemUrl']");
        return this.$el;
      },
      constructor: function ItemGrabber() {
			Backbone.View.prototype.constructor.apply(this, arguments);
			}
    });
  });

}).call(this);