function Controller() {
    var SceneType = Object.freeze({
        QUESTIONS_TITLE: 0,
        QUESTION: 1,
        ANSWERS_TITLE: 2,
        QUESTION_ANSWER: 3,
        END_TITLE: 4
    });
    
    var QuestionType = Object.freeze({
        NORMAL: 'NORMAL',
        WHAT_LINKS: 'WHAT_LINKS'
    });

    this.sceneIndex = 0;
    
    Controller.prototype.onViewReady = function(view) {
        this.view = view;
        this.view.setController(this);
        this.view.onQuizLoading();
        this.loadQuiz();
    };
    
    Controller.prototype.onNext = function() {
        if (this.sceneIndex < this.scenes.length - 1) {
            this.sceneIndex++;
            this.showScene();
        }
    };

    Controller.prototype.onPrevious = function() {
        if (this.sceneIndex > 0) {
            this.sceneIndex--;
            this.showScene();
        }
    };

    Controller.prototype.loadQuiz = function() {
        var _this = this;
        $.get("api/quiz", function (quiz) {
            _this.onQuizLoaded(quiz);
        });
    };
    
    Controller.prototype.onQuizLoaded = function(quiz) {
        this.scenes = buildScenes(quiz);
        this.showScene();
        this.view.enableNavigation();
    };
    
    Controller.prototype.showScene = function() {
        var scene = this.scenes[this.sceneIndex];
        var question = scene.question;
        var view = this.view;

        switch(scene.type) {
            case SceneType.QUESTIONS_TITLE:
                view.showQuestionsTitle(scene.date);
                view.showTitlePage();
                break;
            case SceneType.QUESTION:
                view.showQuestionNumber(question.number);
                view.showQuestion(
                    scene.question.question,
                    scene.question.type === QuestionType.WHAT_LINKS
                );
                view.showAnswer('');
                view.showQuestionPage();
                break;
            case SceneType.ANSWERS_TITLE:
                view.showTitlePage();
                view.showAnswersTitle();
                break;
            case SceneType.QUESTION_ANSWER:
                view.showQuestionNumber(question.number);
                view.showQuestion(
                    question.question,
                    question.type === QuestionType.WHAT_LINKS
                );
                view.showAnswer(question.answer);
                view.showQuestionPage();
                break;
            case SceneType.END_TITLE:
                view.showEndTitle();
                view.showTitlePage();
                break;
        }
    };
    
    function buildScenes(quiz) {
        var scenes = [];
        // First just show the questions
        scenes.push({
            type: SceneType.QUESTIONS_TITLE,
            date: quiz.date
        });
        for (var i = 0; i < quiz.questions.length; i++) {
            scenes.push({
                type: SceneType.QUESTION,
                question: quiz.questions[i]
            });
        }
        scenes.push({
            type: SceneType.ANSWERS_TITLE
        });
        // Now recap the questions, showing the answer after each one
        for (i = 0; i < quiz.questions.length; i++) {
            scenes.push({
                type: SceneType.QUESTION,
                question: quiz.questions[i]
            });
            scenes.push({
                type: SceneType.QUESTION_ANSWER,
                question: quiz.questions[i]
            });
        }
        scenes.push({
            type: SceneType.END_TITLE
        });
        
        return scenes;
    }
}
