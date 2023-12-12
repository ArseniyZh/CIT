#include <iostream>
#include <limits>
#include <map>

using namespace std;


class User {
public:
    User(string name) {
        self_name = name;
        scores = 0;
    }

    int getScores() {
        return scores;
    };

    void upScores(int score) {
        scores += score;
    };

private:
    string self_name;
    int scores;
};



class Question {
public:
    Question(
             string title,
             std::map<int, string> answers,
             int correct_answer
             ) {
        self_title = title;
        self_answers = answers;
        self_correct_answer = answers[correct_answer];
    }

    void displayData() {
        cout << "Question: " << self_title << endl;
        cout << "Answers:" << endl;
        for (int i = 1; i <= self_answers.size(); i++) {
            cout << i << " - " << self_answers[i] << endl;
        };
    };

    bool checkAnswer(int answer) {
        bool result = (self_answers[answer] == self_correct_answer);

        if (result) {
            cout << "Correct!" << endl << endl;
        } else {
            cout << "Incorrect. Correct answer is " << self_correct_answer << endl<< endl;
        };
        return result;
    };

private:
    string self_title;
    std::map<int, string> self_answers;
    string self_correct_answer;
};


int getPositiveIntegerInput(std::map<int, string> answers) {
    int input;
    while (true) {
        cout << "Answer number...: ";
        cin >> input;

        if (answers.count(input) == 0 || cin.fail()) {
            cin.clear();
            cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            cout << "There is no such answer" << endl << endl;
        } else {
            break;
        };
    };
    return input;
}


int main() {
    string name;
    int answer1, answer2, answer3, answer4, answer5;
    int score_constant = 5;

    cout << "What's your name? : ";
    cin >> name;

    User user(name);
    cout << "Hello, " << name << endl << "Your initial scores are as follows " << user.getScores() << endl;
    cout << "Each question gives 5 points. If you score 20, you win" << endl << endl;


    std::map<int, string> answers1 = {{1, "2 floors"}, {2, "3 floors"}, {3, "4 floors"}};
    Question question1("How many floors are there in the 7th KAI building?", answers1, 3);
    question1.displayData();
    answer1 = getPositiveIntegerInput(answers1);

    if (question1.checkAnswer(answer1)) {
        user.upScores(score_constant);
    };


    std::map<int, string> answers2 = {{1, "Berlin"}, {2, "London"}, {3, "Paris"}};
    Question question2("What is the capital of France?", answers2, 3);
    question2.displayData();
    answer2 = getPositiveIntegerInput(answers2);

    if (question2.checkAnswer(answer2)) {
        user.upScores(score_constant);
    };


    std::map<int, string> answers3 = {{1, "Venus"}, {2, "Mars"}, {3, "Jupiter"}};
    Question question3("Which planet is known as the 'Red Planet'?", answers3, 2);
    question3.displayData();
    answer3 = getPositiveIntegerInput(answers3);

    if (question3.checkAnswer(answer3)) {
        user.upScores(score_constant);
    };


    std::map<int, string> answers4 = {{1, "Charles Dickens"}, {2, "William Shakespeare"}, {3, "Jane Austen"}};
    Question question4("Who wrote the play 'Romeo and Juliet'?", answers4, 2);
    question4.displayData();
    answer4 = getPositiveIntegerInput(answers4);

    if (question4.checkAnswer(answer4)) {
        user.upScores(score_constant);
    };


    std::map<int, string> answers5 = {{1, "African Elephant"}, {2, "Blue Whale"}, {3, "Giraffe"}};
    Question question5("What is the largest mammal in the world?", answers5, 2);
    question5.displayData();
    answer5 = getPositiveIntegerInput(answers5);

    if (question5.checkAnswer(answer5)) {
        user.upScores(score_constant);
    };


    if (user.getScores() >= 20) {
        cout << "Congratulations, " << name << "! You won the game! " << "You scored " << user.getScores() << " point!" << endl;
    } else {
        cout << "You couldn't score the required points" << endl;
    };

    return 0;
}
