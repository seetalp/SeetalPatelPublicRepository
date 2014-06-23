var app = angular.module('gradebookModule', []);
var pageInfo = {};

app.factory('gradebookFactory', function ($http) {
    var factory = {};
    var url = '/api/gradebook/';

    factory.getAllGrades = function () {
        return $http.get(url + classId);
    };

    factory.updateGrade = function (newGradeInfo) {
        return $http.put(url, newGradeInfo);
    };

    return factory;
});

app.controller('DisplayCtrl', function ($scope, gradebookFactory) {
    gradebookFactory.getAllGrades()
        .success(function (data) {
            pageInfo = data;
            $scope.allGrades = pageInfo;
        })
        .error(function (message, status) {
            alert(message + 'status: ' + status);
        });
    $scope.save = function (EntryID, student, PointsScored) {
        var percentGrade = calculateNewGrade(student, EntryID);
        var output = {
            StudentID: student.StudentID,
            EntryID: EntryID,
            PointsScored: PointsScored,
            PercentGrade: percentGrade,
            LetterGrade: student.LetterGrade,
            ClassID: classId
        };
        gradebookFactory.updateGrade(output);
    };

    var calculateNewGrade = function (student, EntryID) {
        var totScored = 0;
        var totPossible = 0;
        var percentGrade = 0;
        var totPercent;

        for (var i = 0; i < student.Assignments.length; i++) {
            if (student.Assignments[i].EntryID === EntryID) {
                student.Assignments[i].PercentGrade = student.Assignments[i].PointsScored / student.Assignments[i].PointsPossible * 100;
                percentGrade = student.Assignments[i].PercentGrade;
            }
            if (student.Assignments[i].PointsScored !== null) {
                totScored += student.Assignments[i].PointsScored;
                totPossible += student.Assignments[i].PointsPossible;
            }
        }

        if(totPossible)
            totPercent = (totScored / totPossible) * 100;

        if (totPercent >= 90)
            student.LetterGrade = 'A';
        else if (totPercent >= 80)
            student.LetterGrade = 'B';
        else if (totPercent >= 70)
            student.LetterGrade = 'C';
        else if (totPercent >= 60)
            student.LetterGrade = 'D';
        else if(totPercent >= 0)
            student.LetterGrade = 'F';
        else 
            student.LetterGrade = '';


        return percentGrade;
    };
});

app.controller('EnterGradeCtrl', function ($scope) {
    $scope.editMode = false;

    $scope.changeMode = function () {
        $scope.editMode = !$scope.editMode;
    };
});