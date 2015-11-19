angular.module('popoverAutoclose', [])
.directive('popoverAutoclose', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var timeoutHandle;

            scope.$watch('tt_isOpen', function (isOpen) {
                $timeout.cancel(timeoutHandle);

                if (isOpen) {
                    timeoutHandle = $timeout(function () {
                        scope.tt_isOpen = false;
                    }, +attrs.popoverAutoclose || 5000);
                }
            });
        }
    }
});