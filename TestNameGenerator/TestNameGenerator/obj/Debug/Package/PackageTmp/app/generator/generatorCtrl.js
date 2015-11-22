(function () {
    "use strict";

    function GeneratorCtrl($timeout, ngAudio) {
        var vm = this;
        vm.convertedText = "";
        vm.textBeforeConverted = "";
        vm.convertedTextWithHeader = ""; //Include suffix & prefix if needed
        vm.audio = ngAudio.load("app/generator/ClashofClans_sms8.mp3"); //http://static1.grsites.com/archive/sounds/birds/birds007.wav");
        vm.isIncludePreSuf = true;
        var minlength = 5;
        var maxlength = 136;

        vm.m_Open_Bracket = "[";
        vm.m_Close_Bracket = "]";
        vm.m_TestMethod = "TestMethod";
        vm.m_Public_Void = "\npublic void ";
        vm.m_Round_Brackets = "() ";
        vm.m_Braces = "{ }";

        vm.success = function () {
            console.log('Copied!');

            vm.playSound();
            vm.lightOn();

            $timeout(vm.lightOff, 3000); //for angular            
        };

        vm.fail = function (err) {
            console.error('Error!', err);

            vm.lightOff();
        };

        vm.lightOn = function () {
            $("input[value='on']").prop('checked', true);
        };

        vm.lightOff = function () {
            $("input[value='on']").prop('checked', false);
        };

        vm.clearText = function () {
            vm.convertedText = null;
            vm.textBeforeConverted = null;
        };

        vm.triggerCopy = function (event) {
            if (event.keyCode === 13 && vm.textBeforeConverted.length >= minlength) { //Enter key
                $(".btn-success").click();
                event.preventDefault();
                return;
            }
        };

        vm.beforeCopy = function () {
            if (vm.textBeforeConverted === undefined || vm.textBeforeConverted === "") {
                vm.convertedText = "";
                return;
            }

            if (vm.textBeforeConverted === maxlength) {
                return;
            }

            vm.convertedText = vm.textBeforeConverted.replace(/\w\S*/g, function (txt) {
                return txt.charAt(0).toUpperCase() + txt.slice(1);
            });
            vm.convertedText = allowedChars(vm.convertedText);
            vm.convertedText = replaceSpacesWithUnderscore(vm.convertedText);
            vm.convertedText = replaceMultiplaeOccuranceWithOneUnderscore(vm.convertedText);

            if (vm.isIncludePreSuf) {
                buildTextWithPrefixnSuffix();
            }
        };

        vm.playSound = function () {
            vm.audio.play();
        }

        vm.mousedown = function () {
        };

        function replaceSpacesWithUnderscore(str) {
            return str.replace(/ +/g, '_'); //+ for many spaces to one underscore
        }

        function replaceMultiplaeOccuranceWithOneUnderscore(str) {
            return str.replace(/_+/g, '_'); //+ for many '_' to one underscore
        }

        function allowedChars(str) {
            return str.replace(/[^a-z0-9 _]/ig, ''); //What allowed
        }

        function buildTextWithPrefixnSuffix() {
            vm.convertedText = "[TestMethod]\npublic void " + vm.convertedText + "() " + "{ " + " /* WRITE HERE THE TESTCASE NO. */" + "\n}";
        }
    }

    angular.module("testNameGenerator")
        .controller("GeneratorCtrl",
            GeneratorCtrl);
}());