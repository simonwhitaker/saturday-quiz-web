$(function(){
    onViewReady();

    function onViewReady() {
        hideAllPages();
        setUpNavigation();
        loadQuiz();
    }

    function loadQuiz() {
        $.get("api/quiz", function(quiz){
            setQuizDate(new Date(quiz.date).toLocaleDateString('en-GB', { day: 'numeric', month: 'long', year: 'numeric' }));
            setTitle("Ready?");
            showTitlePage();
        });
    }
    
    function setUpNavigation() {
        $('#nav-left').click(function(){
            onPrevious();
        });
        $('#nav-right').click(function(){
            onNext();
        });        
    }
    
    function onNext() {
        console.log("nav next")
    }
    
    function onPrevious() {
        console.log("nav previous")
    }
    
    function setQuizDate(date) {
        $('#quiz-date').text(date);
    }
    
    function setTitle(title) {
        $('#title').text(title);
    }
    
    function setQuestionNumber(number) {
        $('#question-number').text(number);
    }
    
    function setQuestion(question) {
        $('#question').html(question);
    }
    
    function setAnswer(answer) {
        $('#answer').html(answer);
    }
    
    function hideAllPages() {
        $('.page').hide();
    }

    function showTitlePage() {
        $('#page-question').hide();
        $('#page-title').show();
    }

    function showQuestionPage() {
        $('#page-title').hide();
        $('#page-question').show();
    }
});