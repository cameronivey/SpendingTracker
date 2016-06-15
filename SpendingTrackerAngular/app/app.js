'use strict';

   angular.module('SpendingTracker', ['ui.bootstrap', 'ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/views/summary.html',
            controller: 'SummaryCtrl'
        })
        .when('/summary', {
            templateUrl: 'app/views/summary.html',
            controller: 'SummaryCtrl'
        })
        .when('/transaction', {
            templateUrl: 'app/views/transaction.html',
            controller: 'TransactionCtrl'
        })
        .when('/category', {
            templateUrl: 'app/views/category.html',
            controller: 'CategoryCtrl'
        })

       
    }]);
