var app = angular.module('rosterSection', []).config(function($httpProvider) {
    $httpProvider.defaults.headers["delete"] = {
        'Content-Type': 'application/json;charset=utf-8'
    };
    //$httpProvider.defaults.headers["post"] = {
    //    'Content-Type': 'application/json;charset=utf-8'
    //};
});

app.factory('rosterFactory', function ($http) {
    var factory = {};
    var url = '/api/rosterapi/'; // path must match {controllername}Controller, in this case you called it RosterApi

    factory.getRoster = function () {
        return $http.get(url + classId);
    };

    factory.deleteStudent = function(id, studentId) {
        return $http.delete(url, { data: { ClassID: id, StudentID: studentId } });
    };

    //Eugene add your syntax here and keep in mind we are using rosterSection not rosterModule

    factory.search = function (searchRequest) {
        return $http.get(url, { params: { ClassID: classId, LastName: searchRequest.LastName, GradeLevel: searchRequest.GradeLevel } });
    };

    factory.addStudent = function (classId, studentId) {
        return $http.post(url, { ClassID: classId, StudentID: studentId });
    };

    return factory;
});


app.controller('rosterCtrl', function ($scope, rosterFactory) {

    $scope.searchRequest = {};
    $scope.searchRequest.ClassID = classId;

//get roster
    $scope.getRoster = function () {
        rosterFactory.getRoster()
            .success(function(data) {
                $scope.studentRoster = data; // this is overwriting the function name
            })
            .error(function(message, status) {
                toastr.error(message, status);
            });
    };

    //delete student
    $scope.deleteStudent = function (classId, studentId) {
        if (confirm('Are you sure you want to delete this student from the roster?')) {
            rosterFactory.deleteStudent(classId, studentId)
                .success(function () {
                    $scope.getRoster();
                toastr.success('Student removed from class');
            })
            .error(function (message, status) {
             toastr.error(message, status);
            });

        }
    }

//search for student

    $scope.search = function () {
        rosterFactory.search($scope.searchRequest)
            .success(function (data) { 
                $scope.searchResults = data; 
            })
            .error(function (message, status) {
                toastr.error(message, status);
            });
    };

    // add a student 
    $scope.addStudent = function (studentId) {
        rosterFactory.addStudent(classId, studentId)
                .success(function () { 
                    $scope.getRoster(); 
                    toastr.success('Student added to class'); 
                    $scope.searchResults = []; 
                })
            .error(function (message, status) {
                toastr.error(message, status);
            });

    };


    //roster list on page load
    $scope.getRoster();
});