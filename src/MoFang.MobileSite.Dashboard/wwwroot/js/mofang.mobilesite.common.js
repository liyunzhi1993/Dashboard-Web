//一些通用js
var openPhotoSwipe = function (index, items, disableAnimation) {
    var pswpElement = document.querySelectorAll('.pswp')[0],
        gallery,
        options;
    // define options (if needed)
    options = {
        barsSize: {
            top: 100,
            bottom: 100
        },
        fullscreenEl: false, // 是否支持全屏按钮
        shareButtons: [
            { id: 'wechat', label: '分享微信', url: '#' },
            { id: 'weibo', label: '新浪微博', url: '#' },
            { id: 'download', label: '保存图片', url: '{{raw_image_url}}', download: true }
        ]
    };
    for (var j = 0; j < items.length; j++) {
        if (items[j].id == index) {
            options.index = j;
            break;
        }
    }

    if (disableAnimation) {
        options.showAnimationDuration = 0;
    }

    // Pass data to PhotoSwipe and initialize it
    gallery = new PhotoSwipe(pswpElement, PhotoSwipeUI_Default, items, options);

    gallery.listen('imageLoadComplete', function (index, item) {
        if (item.w < 1 || item.h < 1) { // unknown size
            var img = new Image();
            img.onload = function () { // will get size after load
                item.w = this.width; // set image width
                item.h = this.height; // set image height
                gallery.invalidateCurrItems(); // reinit Items
                gallery.updateSize(true); // reinit Items
            }
            img.src = item.src; // let's download image
        }
    });

    gallery.init();
};
var validateForm = function (id, option) {
    option = $.extend({}, {
        highlight: function (element) {
            $(element).parent().addClass('has-error');
        },
        success: function (element) {
            $(element).parent().removeClass('has-error');
            $(element).remove();
        },
        errorPlacement: function (err, element) {
            err.addClass("help-block text-danger");
            element.parent().append(err);
        },
        errorElement: "span"
    }, option)
    $(id).validate(option);
};

//格式化时间
Vue.filter('formatDate', function (value, fmt) {
    if (value) {
        if (!fmt) {
            return moment(String(value)).format('YYYY-MM-DD HH:mm:ss')
        } else {
            return moment(String(value)).format(fmt);
        }
    }
})
var formatDate = Vue.filter('formatDate');


