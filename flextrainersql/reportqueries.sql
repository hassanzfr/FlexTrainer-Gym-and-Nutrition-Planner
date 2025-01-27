-- Creations 
CREATE TABLE account (
    accountId NUMERIC PRIMARY KEY,
    userName NVARCHAR(255),
    passwords NVARCHAR(255),
    currStatus NVARCHAR(255)
);
CREATE TABLE users (
    userId NVARCHAR(20) PRIMARY KEY,
    accountId NUMERIC,
    roles NVARCHAR(255),
    fName NVARCHAR(255),
    lName NVARCHAR(255),
    age NUMERIC,
    userAddress NVARCHAR(255),
    email NVARCHAR(255),
    cnic NVARCHAR(255),
    FOREIGN KEY (accountId) REFERENCES account(accountId)
);
SELECT * FROM [plans];SELECT * FROM [diet_plan];SELECT * FROM [meal];SELECT * FROM [daily_routine];SELECT * FROM [workout_plan];SELECT * FROM [exercise];SELECT * FROM [daily_routine_conatins_exercise];SELECT * FROM [feedback];SELECT * FROM [account];SELECT * FROM [users];SELECT * FROM [audit_log];SELECT * FROM [membership];SELECT * FROM [member];SELECT * FROM [metrics];SELECT * FROM [owner];SELECT * FROM [trainer_works_for_gym];SELECT * FROM [record];SELECT * FROM [trainingSession];SELECT * FROM [workoutlog];SELECT * FROM [calorielog];SELECT * FROM [gym];SELECT * FROM [member_follows_plan];SELECT * FROM [trainer];SELECT * FROM [equipment];SELECT * FROM [admin];SELECT * FROM [daily_target];SELECT * FROM [food_items];SELECT * FROM [allergen];SELECT * FROM [gym_feedback];SELECT * FROM [daily_target_meal];

CREATE TABLE record (
    recId NUMERIC PRIMARY KEY,
	userId NVARCHAR(20),
    FOREIGN KEY (userId) REFERENCES users(userId)
);
ALTER TABLE workoutlog
ALTER COLUMN caloriesBurnt NUMERIC; -- Adjust the length as per your requirement
select*from account
select* from users

drop table daily_routine_conatins_exercise
delete from daily_routine
select*from meal
INSERT INTO allergen values ('')
CREATE TABLE owner (
    userId NVARCHAR(20) PRIMARY KEY,
    joinDate NVARCHAR(255),
    FOREIGN KEY (userId) REFERENCES users(userId)
);
CREATE TABLE gym (
    gymId NUMERIC PRIMARY KEY,
    userId NVARCHAR(20),
    gymName NVARCHAR(255),
    approvalStatus NVARCHAR(255),
    FOREIGN KEY (userId) REFERENCES owner(userId)
);
CREATE TABLE membership (
    memId NUMERIC PRIMARY KEY,
    membershipType NVARCHAR(255),
    gymId NUMERIC,
    startDate NVARCHAR(255),
    endDate NVARCHAR(255),
    FOREIGN KEY (gymId) REFERENCES gym(gymId)
);
CREATE TABLE member (
    userId NVARCHAR(20) PRIMARY KEY,
    memId NUMERIC,
    gymId NUMERIC,
    FOREIGN KEY (gymId) REFERENCES gym(gymId),
    FOREIGN KEY (userId) REFERENCES users(userId),
    FOREIGN KEY (memId) REFERENCES membership(memId)
);
CREATE TABLE admin (
    userId NVARCHAR(20) PRIMARY KEY,
    workLocation NVARCHAR(255),
    FOREIGN KEY (userId) REFERENCES users(userId)
);
CREATE TABLE trainer (
    UserId NVARCHAR(20) PRIMARY KEY,
    gymId NUMERIC,
    specialization NVARCHAR(255),
    experience NVARCHAR(255),
    rating NUMERIC,
    NoOfClients NUMERIC,
    FOREIGN KEY (userId) REFERENCES users(userId),
    FOREIGN KEY (gymId) REFERENCES gym(gymId)
);
CREATE TABLE metrics (
    metId NUMERIC PRIMARY KEY,
    gymId NUMERIC,
    memGrowth NUMERIC,
    financPerformance NUMERIC,
    attRate NUMERIC,
    custSatisfact NUMERIC,
    FOREIGN KEY (gymId) REFERENCES gym(gymId)
);
CREATE TABLE trainer_works_for_gym (
    userId NVARCHAR(20),
    gymId NUMERIC,
    FOREIGN KEY (gymId) REFERENCES gym(gymId),
    FOREIGN KEY (userId) REFERENCES trainer(userId),
    PRIMARY KEY(userId, gymId)
);
CREATE TABLE record (
    recId NUMERIC PRIMARY KEY,
    userId NVARCHAR(20),
    FOREIGN KEY (userId) REFERENCES trainer(userId)
);
CREATE TABLE feedback (
    feedbackId NVARCHAR(20),
    memberId NVARCHAR(20),
    trainerId NVARCHAR(20),
    ratings NUMERIC,
    FOREIGN KEY (memberId) REFERENCES member(userId),
    FOREIGN KEY (trainerId) REFERENCES trainer(userId)
);
CREATE TABLE trainingSession (
    sessionId NUMERIC PRIMARY KEY,
    trainerId NVARCHAR(20),
    memberId NVARCHAR(20),
    sessionDate NVARCHAR(255),
    timeTaken NUMERIC,
    duration NUMERIC,
    FOREIGN KEY (trainerId) REFERENCES trainer(userId),
    FOREIGN KEY (memberId) REFERENCES member(userId)
);
CREATE TABLE workoutlog (
    wlId NUMERIC PRIMARY KEY,
    memberId NVARCHAR(20),
    wDate NUMERIC,
    caloriesBurnt NUMERIC,
    purpose NVARCHAR(255),
    FOREIGN KEY (memberId) REFERENCES member(userId)
);
CREATE TABLE calorielog (
    clId NUMERIC PRIMARY KEY,
    memberId NVARCHAR(20),
    logDate NVARCHAR(255),
    calories NUMERIC,
    proteins NUMERIC,
    fibre NUMERIC,
    fat NUMERIC,
    carbs NUMERIC,
    FOREIGN KEY (memberId) REFERENCES member(userId)
);
CREATE TABLE plans (
    planId NUMERIC PRIMARY KEY,
    creatorId NVARCHAR(20),
    visibility NVARCHAR(255),
    FOREIGN KEY (creatorId) REFERENCES users(userId)
);
CREATE TABLE member_follows_plan (
    planId NUMERIC,
    memberId NVARCHAR(20),
    FOREIGN KEY (memberId) REFERENCES member(userId),
    FOREIGN KEY (planId) REFERENCES plans(planId)
);
CREATE TABLE diet_plan (
    planId NUMERIC PRIMARY KEY,
    purpose NVARCHAR(255),
    dietDesc NVARCHAR(255),
    FOREIGN KEY (planId) REFERENCES plans(planId)
);
CREATE TABLE workout_plan (
    planId NUMERIC PRIMARY KEY,
    workoutDesc NVARCHAR(255),
    diffLevel NVARCHAR(255),
    goal NVARCHAR(255),
    FOREIGN KEY (planId) REFERENCES plans(planId)
);

CREATE TABLE exercise (
    exName NVARCHAR(255) PRIMARY KEY,
    reps NUMERIC,
    exSet NUMERIC,
    rest NUMERIC,
    muscleGroup NVARCHAR(255)
);
CREATE TABLE daily_routine_contains_exercise (
    dayNo NUMERIC,
    exName NVARCHAR(255),
    FOREIGN KEY (dayNo) REFERENCES daily_routine(dayNo),
    FOREIGN KEY (exName) REFERENCES exercise(exName)
);
CREATE TABLE equipment (
    eqName NVARCHAR(255) PRIMARY KEY,
    descr NVARCHAR(255),
    addedDate NVARCHAR(255)
);
CREATE TABLE daily_target (
    dtID NUMERIC PRIMARY KEY,
    dayNo NUMERIC,
    planId NUMERIC,
    FOREIGN KEY (planId) REFERENCES plans(planId)
);
CREATE TABLE meal (
    mealName NVARCHAR(255) PRIMARY KEY,
    descr NVARCHAR(255),
    purpose NVARCHAR(255),
    dietType NVARCHAR(255)
);
CREATE TABLE food_items (
    itemName NVARCHAR(255) PRIMARY KEY,
    fibre NVARCHAR(255),
    protein NVARCHAR(255),
    carbs NVARCHAR(255),
    fats NVARCHAR(255),
    calories NVARCHAR(255)
);
CREATE TABLE allergen (
    allName NVARCHAR(255) PRIMARY KEY
);
CREATE TABLE gym_feedback (
    gymId NUMERIC PRIMARY KEY,
    details NVARCHAR(255),
    rating NUMERIC
);
CREATE TABLE requests (
    reqId NUMERIC PRIMARY KEY,
    roles NVARCHAR(255),
    userId NVARCHAR(20),
    currStatus NVARCHAR(255),
    FOREIGN KEY (userId) REFERENCES users(userId)
);

-- New table to link daily_target to meal
CREATE TABLE daily_target_meal (
    dtID NUMERIC,
    mealName NVARCHAR(255),
    FOREIGN KEY (dtID) REFERENCES daily_target(dtID),
    FOREIGN KEY (mealName) REFERENCES meal(mealName),
    PRIMARY KEY(dtID, mealName)
);


-- Inserting into account
INSERT INTO account VALUES (1, 'User1', 'Password1', 'Active');
INSERT INTO account VALUES (2, 'User2', 'Password2', 'Active');
INSERT INTO account VALUES (3, 'User3', 'Password3', 'Active');

-- Inserting into users
INSERT INTO users VALUES ('User1', 1, 'Owner', 'First1', 'Last1', 30, 'Address1', 'Email1', 'CNIC1');
INSERT INTO users VALUES ('User2', 2, 'Member', 'First2', 'Last2', 25, 'Address2', 'Email2', 'CNIC2');
INSERT INTO users VALUES ('User3', 3, 'Trainer', 'First3', 'Last3', 35, 'Address3', 'Email3', 'CNIC3');

-- Inserting into owner
INSERT INTO owner VALUES ('User1', '2024-01-01');

-- Inserting into gym
INSERT INTO gym VALUES (1, 'User1', 'Gym1', 'Approved');

-- Inserting into membership
INSERT INTO membership VALUES (1, 'Type1', 1, '2024-01-01', '2024-12-31');

-- Inserting into member
INSERT INTO member VALUES ('User2', 1, 1);

-- Inserting into trainer
INSERT INTO trainer VALUES ('User3', 1, 'Specialization1', 'Experience1', 5, 10);

-- Inserting into trainer_works_for_gym
INSERT INTO trainer_works_for_gym VALUES ('User3', 1);

-- Inserting into plans
INSERT INTO plans VALUES (1, 'User3', 'Public');

-- Inserting into diet_plan
INSERT INTO diet_plan VALUES (1, 'Weight Loss', 'Diet Description');

-- Inserting into member_follows_plan
INSERT INTO member_follows_plan VALUES (1, 'User2');

-- Inserting into meal
INSERT INTO meal VALUES ('Meal1', 'Description1', 'Breakfast', 'Vegan');

-- Inserting into daily_target
INSERT INTO daily_target VALUES (1, 1, 1);

-- Inserting into daily_target_meal
INSERT INTO daily_target_meal VALUES (1, 'Meal1');

-- Inserting into food_items
INSERT INTO food_items VALUES ('FoodItem1', 10, 20, 30, 40, 500);

-- Inserting into allergen
INSERT INTO allergen VALUES ('Peanuts');

-- Inserting into equipment
INSERT INTO equipment VALUES ('Equipment1', 'Description1', '2024-01-01');

-- Inserting into workout_plan
INSERT INTO workout_plan VALUES (1, 'Workout Description', 'Beginner', 'Muscle Gain');

-- Inserting into exercise
INSERT INTO exercise VALUES ('Exercise1', 10, 3, 60, 'Chest');

-- Inserting into daily_routine
INSERT INTO daily_routine VALUES (1, 1, 1);

-- Inserting into daily_routine_contains_exercise
INSERT INTO daily_routine_contains_exercise VALUES (1, 'Exercise1');





-- Inserting into account
INSERT INTO account VALUES (4, 'User4', 'Password4', 'Active');
INSERT INTO account VALUES (5, 'User5', 'Password5', 'Active');
select*from member
-- Inserting into users
INSERT INTO users VALUES ('User4', 4, 'Member', 'First4', 'Last4', 28, 'Address4', 'Email4', 'CNIC4');
INSERT INTO users VALUES ('User5', 5, 'Trainer', 'First5', 'Last5', 32, 'Address5', 'Email5', 'CNIC5');

-- Inserting into member
INSERT INTO member VALUES ('User4', 1, 1);

-- Inserting into trainer
INSERT INTO trainer VALUES ('User5', 1, 'Specialization2', 'Experience2', 4.5, 8);

-- Inserting into trainer_works_for_gym
INSERT INTO trainer_works_for_gym VALUES ('User5', 1);

-- Inserting into meal
INSERT INTO meal VALUES ('Meal2', 'Description2', 'Lunch', 'Vegetarian');

-- Inserting into daily_target_meal
INSERT INTO daily_target_meal VALUES (1, 'Meal2');

-- Inserting into food_items
INSERT INTO food_items VALUES ('FoodItem2', 15, 25, 35, 45, 400);

-- Inserting into allergen
INSERT INTO allergen VALUES ('No Peanuts');

-- Inserting into equipment
INSERT INTO equipment VALUES ('Equipment2', 'Description2', '2024-01-02');

-- Inserting into exercise
INSERT INTO exercise VALUES ('Exercise2', 12, 4, 60, 'Legs');

-- Inserting into daily_routine_contains_exercise
INSERT INTO daily_routine_contains_exercise VALUES (1, 'Exercise2');



-- Inserting into account
INSERT INTO account VALUES (7, 'User7', 'Password7', 'Active');

-- Inserting into users
INSERT INTO users VALUES ('User7', 7, 'Member', 'First7', 'Last7', 29, 'Address7', 'Email7', 'CNIC7');

-- Inserting into member
INSERT INTO member VALUES ('User7', 1, 1);



SELECT * FROM member
JOIN trainer_works_for_gym ON member.userId = trainer_works_for_gym.userId
WHERE trainer_works_for_gym.gymId = 1 AND trainer_works_for_gym.userId = 'User5';

SELECT * FROM member
JOIN member_follows_plan ON member.userId = member_follows_plan.memberId
WHERE member.gymId = 1 AND member_follows_plan.planId = 1;

SELECT * FROM member
JOIN member_follows_plan ON member.userId = member_follows_plan.memberId
JOIN trainer_works_for_gym ON member.userId = trainer_works_for_gym.userId
WHERE trainer_works_for_gym.userId = 'User5' AND member_follows_plan.planId = 1;

SELECT COUNT(*) FROM member
JOIN daily_routine_contains_exercise ON daily_routine_contains_exercise.drID = member.userId
JOIN exercise ON daily_routine_contains_exercise.exName = exercise.exName
WHERE member.gymId = 1 AND exercise.exName = 'Exercise2';

SELECT * FROM diet_plan
JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID
JOIN meal ON daily_target_meal.mealName = meal.mealName
JOIN food_items ON meal.mealName = food_items.itemName
WHERE meal.purpose = 'Breakfast' AND food_items.calories < 500;

SELECT * FROM diet_plan
JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID
JOIN meal ON daily_target_meal.mealName = meal.mealName
JOIN food_items ON meal.mealName = food_items.itemName
WHERE food_items.carbs < 300;

SELECT * FROM workout_plan
JOIN daily_routine_contains_exercise ON workout_plan.planId = daily_routine_contains_exercise.drID
JOIN exercise ON daily_routine_contains_exercise.exName = exercise.exName
WHERE exercise.exName != 'Exercise2';

 SELECT * FROM diet_plan
JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID
JOIN meal ON daily_target_meal.mealName = meal.mealName
WHERE meal.mealName NOT IN (SELECT allName FROM allergen WHERE allName = 'Peanuts');

SELECT * FROM membership
WHERE startDate >= DATEADD(month, -3, GETDATE());

SELECT gymId, COUNT(*) as TotalMembers FROM member
WHERE gymId IN (1, 2) AND memId IN (SELECT memId FROM membership WHERE startDate >= DATEADD(month, -6, GETDATE()))
GROUP BY gymId;

-- 1. List of members who have been with a specific gym for more than a year.
SELECT * FROM member
JOIN membership ON member.memId = membership.memId
WHERE member.gymId = 1 AND DATEDIFF(year, membership.startDate, GETDATE()) > 1;

-- 2. Find the average rating of all trainers in a specific gym.
SELECT AVG(rating) FROM trainer
JOIN trainer_works_for_gym ON trainer.userId = trainer_works_for_gym.userId
WHERE trainer_works_for_gym.gymId = 1;

-- 3. List of trainers who have more than 10 clients.
SELECT * FROM trainer WHERE NoOfClients > 10;

-- 4. Find the total number of members following a specific workout plan.
SELECT COUNT(*) FROM member_follows_plan WHERE planId = 1;

-- 5. List of members who have a diet plan with a total calorie intake of less than 2000 calories.
SELECT * FROM member
JOIN member_follows_plan ON member.userId = member_follows_plan.memberId
JOIN diet_plan ON member_follows_plan.planId = diet_plan.planId
JOIN daily_target_meal ON diet_plan.planId = daily_target_meal.dtID
JOIN meal ON daily_target_meal.mealName = meal.mealName
JOIN food_items ON meal.mealName = food_items.itemName
GROUP BY member.userId
HAVING SUM(food_items.calories) < 2000;

-- 6. Find the gym with the highest member growth in the last year.
SELECT gymId, COUNT(*) as TotalMembers FROM member
WHERE memId IN (SELECT memId FROM membership WHERE startDate >= DATEADD(year, -1, GETDATE()))
GROUP BY gymId
ORDER BY TotalMembers DESC
LIMIT 1;

-- 7. List of members who have not attended the gym in the last month.
SELECT * FROM member
LEFT JOIN workoutlog ON member.userId = workoutlog.memberId
WHERE workoutlog.wDate < DATEADD(month, -1, GETDATE()) OR workoutlog.wDate IS NULL;

-- 8. Find the most common goal among all workout plans.
SELECT goal, COUNT(*) as Count FROM workout_plan
GROUP BY goal
ORDER BY Count DESC
LIMIT 1;

-- 9. List of gyms that have received a feedback rating of less than 3.
SELECT * FROM gym
JOIN gym_feedback ON gym.gymId = gym_feedback.gymId
WHERE gym_feedback.rating < 3;

-- 10. Find the total number of members who have joined in the last month across all gyms.
SELECT COUNT(*) FROM member
JOIN membership ON member.memId = membership.memId
WHERE membership.startDate >= DATEADD(month, -1, GETDATE());