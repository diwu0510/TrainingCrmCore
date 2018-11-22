var tabs = $('#homeTab').HomeTab({
    contentWrapper: $('#east'),
    max: 10
});

var navs = [];
loadnav();

$("#btn-changePw").on("click", function () {
    layer.open({
        type: 2,
        title: '修改密码',
        shadeClose: false,
        maxmin: true,
        shade: [0.1, '#fff'],
        area: ['480px', '320px'],
        content: "/Admin/Home/ChangePw",
        end: function () { }
    });
});

function onPwChanged() {
    layer.alert("密码修改成功，请重新登录", {
        closeBtn: 0
    }, function () {
        window.location = "/Home/Logout";
    });
}

$.get("/Admin/Home/Menu?r=" + Math.random(), {}, function (data) {
    navs = data;
    loadnav();
});

// 导航
var tablist;

function loadnav() {
    //动态加载导航菜单
    var _html = "";
    var index = 0;
    $.each(navs, function (i, nav) {
        if ((nav.children && nav.children.length > 0) || nav.url) {
            _html += '<li class="item">';
            _html += '    <a href="javascript:void(0);" class="main-nav">';
            _html += '        <div class="main-nav-icon"><i class="fa ' + nav.icon + '"></i></div>';
            _html += '        <div class="main-nav-text">' + nav.name + '</div>';
            _html += '        <span class="arrow"></span>';
            _html += '    </a>';
            _html += getsubnav(nav.children);
            _html += '</li>';
        }
    });
    $("#nav").append(_html);
    $('#nav li a').click(function () {
        var href = $(this).data("href");
        if (href) {
            tabs.open($(this).text);
        }
    });
    $("#nav li.item").hover(function (e) {
        var $sub = $(this).find('.sub-nav-wrap');
        var length = $sub.find('.sub-nav').find('li').length;
        if (length > 0) {
            $(this).addClass('on');
            $sub.show();
            var sub_top = $sub.offset().top + $sub.height();
            var body_height = $(window).height();
            if (sub_top > body_height) {
                $sub.css('bottom', '0px');
            }
        }
    }, function (e) {
        $(this).removeClass('on');
        $(this).find('.sub-nav-wrap').hide();
    });
    $("#nav li.sub").hover(function (e) {
        var $ul = $(this).find('ul');
        $ul.show();
        var top = $(this).find('ul').offset().top;
        var height = $ul.height();
        var wheight = $(window).height();
        if (top + height > wheight) {
            $ul.css('top', parseInt('-' + (height - 11))).css('left', '146px');
        } else {
            $ul.css('top', '0px').css('left', '146px');
        }
    }, function (e) {
        $(this).find('ul').hide();
        $(this).find('ul').css('top', '0px');
    });

    //导航二菜单
    function getsubnav(subData) {
        var _html = '<div class="sub-nav-wrap">';
        _html += '<ul class="sub-nav">';
        $.each(subData, function (i, nav) {
            if (nav.children.length === 0) {
                _html += '<li><a href="javascript:;"';
                if (nav.url) {
                    _html += ' onclick="tabs.open(\'' + nav.name + '\', \'' + nav.url + '\', \'' + (nav.icon ? nav.icon : '') + '\')"';
                }
                _html += '><i class="' + nav.icon + '"></i>' + nav.name + '</a> ';
                _html += getchildnav(nav.children);
                _html += '</li>';
            } else {
                _html += '<li class="sub"><a href="javascript:;"';
                if (nav.url) {
                    _html += ' onclick="tabs.open(\'' + nav.name + '\', \'' + nav.url + '\', \'' + (nav.icon ? nav.icon : '') + '\')"';
                }
                _html += '><i class="' + nav.icon + '"></i>' + nav.name + '</a> ';
                _html += getchildnav(nav.children);
                _html += '</li>'; //sub
            }
        });
        _html += '</ul>';
        _html += '</div>';
        return _html;
    }

    //导航三菜单
    function getchildnav(data) {
        var _html = '<div class="sub-child"><ul>';
        $.each(data, function (i, nav) {
            _html += '<li><a href="javascript:;"';
            if (nav.url) {
                _html += ' onclick="tabs.open(\'' + nav.name + '\', \'' + nav.url + '\', \'' + (nav.icon ? nav.icon : '') + '\')"';
            }
            _html += '><i class="fa ' + nav.icon + '"></i>' + nav.name + '</a></li>';
        });
        _html += '</ul></div>';
        return _html;
    }

    //判断是否有子节点
    function isbelowmenu(moduleId) {
        var count = 0;
        $.each(authorizeMenuData, function (i) {
            if (authorizeMenuData[i].ParentId === moduleId) {
                count++;
                return false;
            }
        });
        return count;
    }
}

$("#btn-logout").on("click", function () {
    layer.confirm("确定退出登录？", {
        btn: ["确定", "取消"]
    }, function () {
        window.location.href = "/Home/Logout";
    });
});

function logout() {
    if (confirm('确认退出？')) {
        window.location.href = "/Home/Logout";
    }
}