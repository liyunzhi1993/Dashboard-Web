//取整
Vue.filter('ceil', function (value) {
    return Math.ceil(value);
})
//格式化时间
Vue.filter('formatDate', function (value, fmt) {
    if (value) {
        if (!fmt) {
            return moment(String(value)).format('YYYY.MM.DD')
        } else {
            return moment(String(value)).format(fmt);
        }
    }
})

var ceil = Vue.filter('ceil');
var formatDate = Vue.filter('formatDate');

//扩展confirm
window.confirm = function (message,fun) {
    $(".confirm-title").html(message);
    $(".confirm").show();
    $(".confirm-cancel").click(function () {
        $(".confirm").hide();
    })
    $(".confirm-ok").click(function () {
        if (fun!=undefined) {
            $(".confirm-ok").unbind();
            fun();
        }
        $(".confirm").hide();
    })
};
//扩展alert，默认实在form前做操作
window.alert = function (data) {
    var alertType = "success";
    var alertMessage = "操作成功";
    if (data.success == false) {
        alertType = "danger";
    }
    if (data.message != "") {
        alertMessage = data.message;
    }
    $(".alert").remove();
    $("form").prev().append("<div class=\"alert alert-" + alertType + " role=\"alert\">" + alertMessage +"</div>")
};