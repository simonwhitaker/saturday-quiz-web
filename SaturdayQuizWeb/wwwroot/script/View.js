﻿function View() {
    View.prototype.setController = function(controller) {
        this.controller = controller;
    };
    
    View.prototype.onQuizLoading = function() {
        $('.page').hide();
    };
    
    View.prototype.enableNavigation = function() {
        var controller = this.controller;
        $('#nav-left').click(function(){
            controller.onPrevious();
        });
        $('#nav-right').click(function(){
            controller.onNext();
        });
        $(document).keyup(function(e) {
            switch (e.which) {
                case 37: // Left
                    controller.onPrevious();
                    break;
                case 39: // Right
                    controller.onNext();
                    break;
                default:
                    return;
            }
            e.preventDefault();
        });
    };

    View.prototype.showTitlePage = function() {
        $('#page-question').hide();
        $('#page-title').show();
    };

    View.prototype.showQuestionPage = function() {
        $('#page-title').hide();
        $('#page-question').show();
    };

    View.prototype.showQuestionsTitle = function(date) {
        var dateString = new Date(date).toLocaleDateString(
            'en-GB',
            {
                day: 'numeric',
                month: 'long',
                year: 'numeric'
            });

        $('#title').text('Ready?');
        $('#quiz-date').text(dateString);
    };

    View.prototype.showAnswersTitle = function() {
        $('#title').text('Answers');
        $('#quiz-date').text('');
    };
    
    View.prototype.showEndTitle = function() {
        $('#title').text('End');
        $('#quiz-date').text('');
    };
    
    View.prototype.showQuestionNumber = function(number) {
        $('#question-number').text(number + '.');
    };
    
    View.prototype.showQuestion = function(questionHtml, isWhatLinks) {
        $('#question').html(questionHtml);
        $('#question-what-links').toggleClass('visible', isWhatLinks);
    };
    
    View.prototype.showAnswer = function(answerHtml) {
        $('#answer').html(answerHtml);
    };
}