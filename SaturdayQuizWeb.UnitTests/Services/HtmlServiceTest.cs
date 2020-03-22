using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SaturdayQuizWeb.Model;
using SaturdayQuizWeb.Services;

namespace SaturdayQuizWeb.UnitTests.Services
{
    [TestFixture]
    public class HtmlServiceTest
    {
        // Object under test
        private readonly HtmlService _htmlService = new HtmlService();
        
        private readonly List<Question> _questions;

        public HtmlServiceTest()
        {
            var html = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "/TestData/2019_07_20_quiz.html");
            _questions = _htmlService.FindQuestions(html);
        }
        
        [Test]
        public void TestQuestionCount()
        {
            Assert.AreEqual(15, _questions.Count);
        }

        [Test]
        public void TestQuestion1()
        {
            var question = _questions[0];
            Assert.AreEqual(1, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("Which Nazi leader died in Paddington in 1981?", question.QuestionText);
            Assert.AreEqual("Albert Speer", question.AnswerText);
            Assert.AreEqual("Which Nazi leader died in Paddington in 1981?", question.QuestionHtml);
            Assert.AreEqual("Albert Speer", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion2()
        {
            var question = _questions[1];
            Assert.AreEqual(2, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("What are produced at La Masia & La Fábrica?", question.QuestionText);
            Assert.AreEqual("Footballers (academies of Barcelona and Real Madrid)", question.AnswerText);
            // Check that normal HTML tags are allowed
            Assert.AreEqual("What are produced at <i>La Masia</i> &amp; <i>La Fábrica</i>?", question.QuestionHtml);
            // Check that <a> tags are removed
            Assert.AreEqual("Footballers (academies of Barcelona and Real Madrid)", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion3()
        {
            var question = _questions[2];
            Assert.AreEqual(3, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("In publishing, what does ISBN stand for?", question.QuestionText);
            Assert.AreEqual("International Standard Book Number", question.AnswerText);
            Assert.AreEqual("In publishing, what does ISBN stand for?", question.QuestionHtml);
            Assert.AreEqual("International Standard Book Number", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion4()
        {
            var question = _questions[3];
            Assert.AreEqual(4, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("Adopted in 1625, what symbol is the Dannebrog?", question.QuestionText);
            Assert.AreEqual("Danish flag", question.AnswerText);
            Assert.AreEqual("Adopted in 1625, what symbol is the Dannebrog?", question.QuestionHtml);
            Assert.AreEqual("Danish flag", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion5()
        {
            var question = _questions[4];
            Assert.AreEqual(5, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("Gabriele Münter was a founder member of what expressionist group?", question.QuestionText);
            Assert.AreEqual("Der Blaue Reiter (Blue Rider)", question.AnswerText);
            Assert.AreEqual("Gabriele Münter was a founder member of what expressionist group?", question.QuestionHtml);
            Assert.AreEqual("Der Blaue Reiter (Blue Rider)", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion6()
        {
            var question = _questions[5];
            Assert.AreEqual(6, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("What was nicknamed the Honourable John Company?", question.QuestionText);
            Assert.AreEqual("East India Company", question.AnswerText);
            Assert.AreEqual("What was nicknamed the Honourable John Company?", question.QuestionHtml);
            Assert.AreEqual("East India Company", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion7()
        {
            var question = _questions[6];
            Assert.AreEqual(7, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("Which country separates Guyana and French Guiana?", question.QuestionText);
            Assert.AreEqual("Suriname", question.AnswerText);
            Assert.AreEqual("Which country separates Guyana and French Guiana?", question.QuestionHtml);
            Assert.AreEqual("Suriname", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion8()
        {
            var question = _questions[7];
            Assert.AreEqual(8, question.Number);
            Assert.AreEqual(QuestionType.Normal, question.Type);
            Assert.AreEqual("In what novel is Constance unhappily married to Sir Clifford?", question.QuestionText);
            Assert.AreEqual("Lady Chatterley’s Lover", question.AnswerText);
            Assert.AreEqual("In what novel is Constance unhappily married to Sir Clifford?", question.QuestionHtml);
            Assert.AreEqual("Lady Chatterley’s Lover", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion9()
        {
            var question = _questions[8];
            Assert.AreEqual(9, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Asgard and Midgard, in the form of a rainbow?", question.QuestionText);
            Assert.AreEqual("Bifrost (bridge in Norse myth, linking gods’ realm and Earth)", question.AnswerText);
            Assert.AreEqual("Asgard and Midgard, in the form of a rainbow?", question.QuestionHtml);
            Assert.AreEqual("Bifrost (bridge in Norse myth, linking gods’ realm and Earth)", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion10()
        {
            var question = _questions[9];
            Assert.AreEqual(10, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Singer O’Dowd; outlaw McCarty; slugger Ruth; bank robber Nelson?", question.QuestionText);
            Assert.AreEqual("Young nicknames: Boy George; Billy the Kid; Babe Ruth; Baby Face Nelson", question.AnswerText);
            Assert.AreEqual("Singer O’Dowd; outlaw McCarty; slugger Ruth; bank robber Nelson?", question.QuestionHtml);
            Assert.AreEqual("Young nicknames: Boy George; Billy the Kid; Babe Ruth; Baby Face Nelson", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion11()
        {
            var question = _questions[10];
            Assert.AreEqual(11, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Statant; sejant; rampant; passant; dormant?", question.QuestionText);
            Assert.AreEqual("Attitudes of animals in heraldry: standing; sitting; rearing; walking; lying down", question.AnswerText);
            Assert.AreEqual("Statant; sejant; rampant; passant; dormant?", question.QuestionHtml);
            Assert.AreEqual("Attitudes of animals in heraldry: standing; sitting; rearing; walking; lying down", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion12()
        {
            var question = _questions[11];
            Assert.AreEqual(12, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Victoria Embankment; Cardiff City Hall; Colchester station?", question.QuestionText);
            Assert.AreEqual("Statues of Boudicca", question.AnswerText);
            Assert.AreEqual("Victoria Embankment; Cardiff City Hall; Colchester station?", question.QuestionHtml);
            Assert.AreEqual("Statues of Boudicca", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion13()
        {
            var question = _questions[12];
            Assert.AreEqual(13, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Khumbu icefall; Kangshung face; Hornbein couloir; Hillary step?", question.QuestionText);
            Assert.AreEqual("Parts of Mount Everest", question.AnswerText);
            Assert.AreEqual("Khumbu icefall; Kangshung face; Hornbein couloir; Hillary step?", question.QuestionHtml);
            Assert.AreEqual("Parts of Mount Everest", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion14()
        {
            var question = _questions[13];
            Assert.AreEqual(14, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Prayers at 6am; 0 degrees longitude; 2, 3, 5, 7, etc?", question.QuestionText);
            Assert.AreEqual("Prime: canonical hour of prayer; prime meridian; prime numbers", question.AnswerText);
            Assert.AreEqual("Prayers at 6am; 0 degrees longitude; 2, 3, 5, 7, etc?", question.QuestionHtml);
            Assert.AreEqual("Prime: canonical hour of prayer; prime meridian; prime numbers", question.AnswerHtml);
        }

        [Test]
        public void TestQuestion15()
        {
            var question = _questions[14];
            Assert.AreEqual(15, question.Number);
            Assert.AreEqual(QuestionType.WhatLinks, question.Type);
            Assert.AreEqual("Prince of Morocco (Au); Prince of Arragon (Ag); Bassanio (Pb)?", question.QuestionText);
            Assert.AreEqual("Caskets chosen by Portia’s suitors in The Merchant Of Venice: gold; silver; lead", question.AnswerText);
            Assert.AreEqual("Prince of Morocco (Au); Prince of Arragon (Ag); Bassanio (Pb)?", question.QuestionHtml);
            Assert.AreEqual("Caskets chosen by Portia’s suitors in The Merchant Of Venice: gold; silver; lead", question.AnswerHtml);
        }
    }
}