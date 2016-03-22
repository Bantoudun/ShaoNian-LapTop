var app = angular.module('eduApp', []);
////////////////////////////////////Topics///////////////////////////////////////////////
app.controller('topicsController', function ($scope, $attrs, $http) {
    //alert($attrs.modelurl)
    $http.get($attrs.modelurl).success(
    function (response) {
        $scope.groups = response;
        $scope.fetchArticleById(0);
    }
    )

    $scope.fetchArticleById = function (Id) {
        $http.get($attrs.modelurl + Id).success(
        function (response) {
            $scope.eduArticle = response;
            var backgroundImg = "url('/images/paper.gif')";
            document.body.style.backgroundImage = backgroundImg;
        }
        )
    }
    
    $scope.$watch('eduArticle', function () {
        //alert("edu changed!");
        if ($scope.eduArticle != undefined) {
            var x = document.getElementById("artContent");
            x.innerHTML = $scope.eduArticle;
        }
    }
)

    $scope.linkHomeWorkById = function (year,term,week) {
        var x = document.getElementById("artContent");
        var backgroundImg = "url('/images/paper.gif')";
        document.body.style.backgroundImage = backgroundImg;
        var imgSrc = "/images/homework/year" + year + "/term" + term + "/" + week + ".jpg";
        x.innerHTML = "<img src='" + imgSrc + "'>";
    }
}
    )

////////////////////////////////////Luntang///////////////////////////////////////////////
app.controller('luntangController', function ($scope, $attrs, $http) {
    //alert($attrs.modelurl)
    $http.get($attrs.modelurl).success(
    function (response) {
        $scope.groups = response;
        //$scope.fetchArticleById(0);
    }
    )

    $scope.fetchArticleById = function (Id) {
        $http.get($attrs.modelurl + Id).success(
        function (response) {
            var result = response;
            $scope.eduArticle = result.eduArticle;
            $scope.follows = result.follows;
            //change background image
            var path = location.pathname.split("/");
            var imgfile = "url('/images/luntangbackground/" + path[path.length - 1] + Id + ".jpg')";
            document.body.style.backgroundImage = imgfile;
            document.body.style.backgroundSize = "100%";
        }
        )
    }

    $scope.$watch('eduArticle', function () {
        //alert("edu changed!");
        if ($scope.eduArticle != undefined) {
            var x = document.getElementById("artContent");
            x.innerHTML = $scope.eduArticle;
        }
    }
        )
}
    )