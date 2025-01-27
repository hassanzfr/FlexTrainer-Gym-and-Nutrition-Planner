CREATE TABLE account (
	accountId NUMERIC PRIMARY KEY,
	userName NVARCHAR(255),
	passwords NVARCHAR(255),
	currStatus NVARCHAR(255),
)
SELECT U.userId
FROM Users U
INNER JOIN Account A ON U.accountId = A.accountId
WHERE A.userName = @userName
AND A.passwords = @password;

UPDATE account
SET currStatus = 'Active'
WHERE accountId = 6;
CREATE TRIGGER InsertGymApprovalRequest
ON gym
AFTER INSERT
AS
BEGIN
    DECLARE @MaxReqId INT;
    SELECT @MaxReqId = ISNULL(MAX(reqId), 0) FROM requests;

    INSERT INTO requests (reqId, userId, roles, request, locationn,currStatus)
    SELECT @MaxReqId + 1, inserted.userId, 'Gym', 'Gym ownership Approval', inserted.gymName,'Pending'
    FROM inserted;
END;
DROP TRIGGER InsertGymApprovalRequest
CREATE TRIGGER UpdateGymApprovalStatus
ON requests
AFTER UPDATE
AS
BEGIN
    IF UPDATE(currStatus)
    BEGIN
        UPDATE g
        SET approvalStatus = CASE WHEN i.currStatus = 'Approved' THEN 'Approved' ELSE 'Rejected' END
        FROM gym g
        INNER JOIN inserted i ON g.gymName = i.locationn
        WHERE i.currStatus IN ('Approved', 'Rejected') AND i.roles = 'Gym';
    END
END;

CREATE TRIGGER InsertTrainerRequest
ON users
AFTER INSERT
AS
BEGIN
    DECLARE @MaxReqId INT;
    SELECT @MaxReqId = ISNULL(MAX(reqId), 0) FROM requests;

    INSERT INTO requests (reqId, roles,userId, request,locationn, currStatus)
    SELECT @MaxReqId + ROW_NUMBER() OVER (ORDER BY inserted.userId), 'Trainer',inserted.userId, 'Trainer Approval',inserted.userAddress, 'Pending'
    FROM inserted
    WHERE inserted.roles = 'Trainer';
END;

CREATE TRIGGER InsertOwnerRequest
ON users
AFTER INSERT
AS
BEGIN
    DECLARE @MaxReqId INT;
    SELECT @MaxReqId = ISNULL(MAX(reqId), 0) FROM requests;

    INSERT INTO requests (reqId, roles,userId, request,locationn, currStatus)
    SELECT @MaxReqId + ROW_NUMBER() OVER (ORDER BY inserted.userId), 'Owner',inserted.userId, 'Owner Approval',inserted.userAddress, 'Pending'
    FROM inserted
    WHERE inserted.roles = 'Owner';
END;
CREATE TRIGGER UpdateOwnerAccountStatus
ON requests
AFTER UPDATE
AS
BEGIN
    IF UPDATE(currStatus)
    BEGIN
        UPDATE A
        SET currStatus = CASE WHEN i.currStatus = 'Approved' THEN 'Active' ELSE 'Rejected' END
        FROM account A
        INNER JOIN users U ON A.accountId = U.accountId
        INNER JOIN inserted i ON U.userId = i.userId
        WHERE i.roles = 'Owner';
    END
END;

SELECT gymId FROM gym WHERE gymName = 'Karachi'
CREATE TRIGGER UpdateTrainerAccountStatus
ON requests
AFTER UPDATE
AS
BEGIN
    IF UPDATE(currStatus)
    BEGIN
        UPDATE A
        SET currStatus = CASE WHEN i.currStatus = 'Approved' THEN 'Active' ELSE 'Rejected' END
        FROM account A
        INNER JOIN users U ON A.accountId = U.accountId
        INNER JOIN inserted i ON U.userId = i.userId
        WHERE i.roles = 'Trainer';
    END
END;


select* from requests
select*from gym
select*from account
select*from users
select*from member
DELETE FROM account WHERE accountId = 1
DELETE FROM membership WHERE memId = 1
DELETE FROM users WHERE userId = 'M1'
INSERT INTO membership VALUES (0,'','','')
CREATE TABLE users (
	userId NVARCHAR(20) PRIMARY KEY,
	accountId NUMERIC,
	roles NVARCHAR(255) ,
	fName NVARCHAR(255),	
	lName NVARCHAR(255),
	age NUMERIC,
	userAddress NVARCHAR(255),
	email NVARCHAR(255),
	cnic NVARCHAR(255),
	FOREIGN KEY (accountId) references account(accountId)
)
INSERT INTO users VALUES ('T8', 8, 'Trainer', 'muqsit', 'iqbal', 25, 'pindi','musqit@gmail.com', 2348495867374)
INSERT INTO account VALUES (8, 'muq', '1234', 'Active')
CREATE TABLE owner (
	userId NVARCHAR(20) PRIMARY KEY,
	joinDate NVARCHAR(255),
	FOREIGN KEY (userId) references users(userId),
)
select* from owner
CREATE TABLE admin (
	userId NVARCHAR(20) PRIMARY KEY,
	workLocation NVARCHAR(255),
	FOREIGN KEY (userId) references users(userId),
)
INSERT INTO admin VALUES('A7','karachi')
CREATE TABLE membership (
	memId NUMERIC PRIMARY KEY,
	membershipType NVARCHAR(255),
	gymId NUMERIC,
	startDate NVARCHAR(255),
	endDate NVARCHAR(255),
	FOREIGN KEY (gymId) REFERENCES gym(gymId)
)

CREATE TABLE member (
	userId NVARCHAR(20) PRIMARY KEY,
	memId NUMERIC,
	gymId NUMERIC,
	FOREIGN KEY (gymId) references gym(gymId),
	FOREIGN KEY (userId) references users(userId),
	FOREIGN KEY (memId) REFERENCES membership(memId)
)
SELECT* FROM users
INSERT INTO gym VALUES (2,'O6','Islamabad','Pending')
CREATE TABLE gym (
	gymId NUMERIC PRIMARY KEY,
	userId NVARCHAR(20),
	gymName NVARCHAR(255),
	approvalStatus NVARCHAR(255),
	FOREIGN KEY (userId) references owner(userId)
)

CREATE TABLE trainer (
	UserId NVARCHAR(20) PRIMARY KEY,
	gymId NUMERIC,
	specialization NVARCHAR(255),
	experience NVARCHAR(255),
	rating NUMERIC,
	NoOfClients NUMERIC,
	FOREIGN KEY (userId) references Users(userId),
	FOREIGN KEY (gymId) references gym(gymId)
)
	 SELECT ROUND(AVG(ratings), 1) AS rounded_average FROM feedback WHERE trainerId = 'T11'
select* from account
CREATE TABLE metrics (
	metId NUMERIC PRIMARY KEY,
	gymId NUMERIC,
	memGrowth NUMERIC,
	financPerformance NUMERIC,
	attRate NUMERIC,
	custSatisfact NUMERIC,
	FOREIGN KEY (gymId) references gym(gymId)
)

CREATE TABLE trainer_works_for_gym (
	userId NVARCHAR(20),
	gymId NUMERIC,
	FOREIGN KEY (gymId) references gym(gymId),
	FOREIGN KEY (userId) references trainer(userId),
	PRIMARY KEY(userId,gymId)
)	

CREATE TABLE record (
	recId NUMERIC PRIMARY KEY,
	userId NVARCHAR(20),
	FOREIGN KEY (userId) references trainer(userId),
)
select*from feedback
UPDATE feedback set feedbackId = 2 where ratings = 10
Insert into feedback (feedbackId, memberId, trainerId, ratings)
                               VALUES ((SELECT MAX(feedbackId) + 1 FROM feedback),'M13', (SELECT userId FROM users WHERE fname = 'Moh') , 9)
CREATE TABLE feedback (
	feedbackId NVARCHAR(20),
	memberId NVARCHAR(20),
	trainerId NVARCHAR(20),
	ratings NUMERIC,
	FOREIGN KEY (memberId) REFERENCES users(userId),
	FOREIGN KEY (trainerId) REFERENCES USERS(userId)
)
s
DROP TABLE feedback

CREATE TABLE trainingSession (
	sessionId NUMERIC PRIMARY KEY,
	trainerId NVARCHAR(20),
	memberId NVARCHAR(20),
	sessionDate NVARCHAR(255),
	timeTaken NUMERIC,
	duration NUMERIC,
	FOREIGN KEY (trainerId) REFERENCES trainer(userId),
	FOREIGN KEY (memberId) REFERENCES member(userId)
)

CREATE TABLE workoutlog (
	wlId NUMERIC PRIMARY KEY,
	memberId NVARCHAR(20),
	wDate NUMERIC,
	caloriesBurnt NUMERIC,
	purpose NVARCHAR(255),
	FOREIGN KEY (memberId) REFERENCES member(userId)
)

CREATE TABLE calorielog (
	clId NUMERIC PRIMARY KEY,
	memberId NVARCHAR(20),
	logDate NVARCHAR(255),
	calories NUMERIC,
	protiens NUMERIC,
	fibre NUMERIC,
	fat NUMERIC,
	carbs NUMERIC,
	FOREIGN KEY (memberId) REFERENCES member(userId)
)

CREATE TABLE plans (
	planId NUMERIC PRIMARY KEY,
	planName NVARCHAR(255),
	creatorId NVARCHAR(20),
	visibility NVARCHAR(255),
	FOREIGN KEY (creatorId) REFERENCES users(userId)
)
-- Inserting the first diet plan
INSERT INTO diet_plan (planId, purpose, dietDesc)
VALUES (1, 'Weight Loss', 'Low-carb, high-protein diet focusing on lean meats, vegetables, and healthy fats.');

-- Inserting the second diet plan
INSERT INTO diet_plan (planId, purpose, dietDesc)
VALUES (2, 'Muscle Gain', 'High-calorie diet with emphasis on protein intake, including lean meats, dairy, and complex carbohydrates.');

-- Inserting the third diet plan
INSERT INTO diet_plan (planId, purpose, dietDesc)
VALUES (3, 'General Health', 'Balanced diet comprising a variety of foods from all food groups, emphasizing whole grains, fruits, vegetables, and lean proteins.');

-- Inserting the fourth diet plan
INSERT INTO diet_plan (planId, purpose, dietDesc)
VALUES (4, 'Athletic Performance', 'High-energy diet tailored to meet the demands of intense physical activity, including ample carbohydrates for fuel, protein for muscle repair, and healthy fats for sustained energy.');


-- Inserting the first plan
INSERT INTO plans (planId, planName, creatorId, visibility)
VALUES (1, 'Weight Loss Plan', 'T11', 'Public');

-- Inserting the second plan
INSERT INTO plans (planId, planName, creatorId, visibility)
VALUES (2, 'Muscle Gain Plan', 'T11', 'Private');

-- Inserting the third plan
INSERT INTO plans (planId, planName, creatorId, visibility)
VALUES (3, 'Fitness Beginner Plan', 'T11', 'Public');

-- Inserting the fourth plan
INSERT INTO plans (planId, planName, creatorId, visibility)
VALUES (4, 'Endurance Training Plan', 'T11', 'Public');


select p.planName, p.creatorId, d.purpose, d.dietDesc
FROM diet_plan d
join plans p on p.planId = d.planId

CREATE TABLE member_follows_plan (
	planId NUMERIC,
	memberId NVARCHAR(20),
	FOREIGN KEY (memberId) REFERENCES member(userId),
	FOREIGN KEY (planId) REFERENCES plans(planId)
)
select*from requests
CREATE TABLE diet_plan (
	planId NUMERIC PRIMARY KEY,
	purpose NVARCHAR(255),
	dietDesc NVARCHAR(255),
	FOREIGN KEY (planId) REFERENCES plans(planId)
)

CREATE TABLE workout_plan (
	planId NUMERIC PRIMARY KEY,
	workoutDesc NVARCHAR(255),
	diffLevel NVARCHAR(255),
	goal NVARCHAR(255),
	FOREIGN KEY (planId) REFERENCES plans(planId)
)
-- Insert workout plans corresponding to PlanID 1 (Weight Loss Plan)
INSERT INTO workout_plan (planId, workoutDesc, diffLevel, goal)
VALUES (1, 'Cardio exercises combined with strength training', 'Intermediate', 'Weight loss and improved cardiovascular health');

-- Insert workout plans corresponding to PlanID 2 (Muscle Building Plan)
INSERT INTO workout_plan (planId, workoutDesc, diffLevel, goal)
VALUES (2, 'Heavy weight lifting focusing on compound exercises', 'Advanced', 'Muscle hypertrophy and strength gains');

-- Insert workout plans corresponding to PlanID 3 (General Fitness Plan)
INSERT INTO workout_plan (planId, workoutDesc, diffLevel, goal)
VALUES (3, 'Mix of cardio, strength training, and flexibility exercises', 'Beginner', 'Overall fitness improvement');

-- Insert workout plans corresponding to PlanID 4 (High Protein Diet Plan)
INSERT INTO workout_plan (planId, workoutDesc, diffLevel, goal)
VALUES (4, 'Moderate intensity workouts with emphasis on protein intake', 'Intermediate', 'Muscle maintenance and fat loss');

CREATE TABLE daily_routine (
	planId Numeric,
	dayNo NUMERIC PRIMARY KEY,
	meal1 NVARCHAR(255),
	meal2 NVARCHAR(255),
	meal3 NVARCHAR(255),
	FOREIGN KEY (meal1) REFERENCES meal(mealName),
	FOREIGN KEY (meal2) REFERENCES meal(mealName),
	FOREIGN KEY (meal3) REFERENCES meal(mealName),
	FOREIGN KEY (planId) REFERENCES diet_plan(planId)
)
-- Inserting meals for day 1
INSERT INTO daily_routine (planId,dayNo, meal1, meal2, meal3)
VALUES (1,1, 'Breakfast', 'Morning Snack', 'Lunch');

-- Inserting meals for day 2
INSERT INTO daily_routine (planId,dayNo, meal1, meal2, meal3)
VALUES (1,2, 'Afternoon Snack', 'Dinner', 'Evening Snack');

-- Inserting meals for day 3
INSERT INTO daily_routine (planId,dayNo, meal1, meal2, meal3)
VALUES (1,3, 'Pre-Workout Snack', 'Post-Workout Meal', 'Bedtime Snack');
	SELECT p.planName,p.creatorId,d.purpose,dr.meal1,dr.meal2,dr.meal3
	FROM daily_routine dr
	JOIN plans p ON dr.planId = p.planId
	join diet_plan d ON dr.planId = d.planId
	WHERE p.planId = 1;

CREATE TABLE exercise (
	exName NVARCHAR(255) PRIMARY KEY,
	reps NUMERIC,
	exSet NUMERIC,
	rest NUMERIC,
	muscleGroup NVARCHAR(255)
)
-- Insert workouts corresponding to PlanID 1 (Weight Loss Plan)
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Running', 30, 3, 60, 'Cardiovascular');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Push-ups', 15, 3, 60, 'Chest, Triceps');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Squats', 20, 3, 60, 'Legs, Glutes');

-- Insert workouts corresponding to PlanID 2 (Muscle Building Plan)
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Deadlifts', 8, 4, 90, 'Back, Hamstrings');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Bench Press', 10, 4, 90, 'Chest, Shoulders, Triceps');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Barbell Rows', 10, 4, 90, 'Back, Biceps');

-- Insert workouts corresponding to PlanID 3 (General Fitness Plan)
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Walking Lunges', 12, 3, 60, 'Legs, Glutes');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Plank', 60, 3, 60, 'Core');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Dumbbell Shoulder Press', 12, 3, 60, 'Shoulders');

-- Insert workouts corresponding to PlanID 4 (High Protein Diet Plan)
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Pull-ups', 10, 4, 90, 'Back, Biceps');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Lunges', 15, 3, 60, 'Legs, Glutes');
INSERT INTO exercise (exName, reps, exSet, rest, muscleGroup)
VALUES ('Dumbbell Bicep Curls', 12, 3, 60, 'Biceps');

CREATE TABLE daily_routine_conatins_exercise (
	dayNo NUMERIC,
	planId Numeric,
	exName1 NVARCHAR(255),
	exName2 NVARCHAR(255),
	exName3 NVARCHAR(255),
	FOREIGN KEY (exName1) REFERENCES exercise(exName),
	FOREIGN KEY (exName1) REFERENCES exercise(exName),
	FOREIGN KEY (exName1) REFERENCES exercise(exName)
)
DROP TABLE daily_routine_conatins_exercise
SELECT p.planName, p.creatorId, wp.workoutDesc, dre.exName1 AS 'Exercise1', dre.exName2 AS 'Exercise2', dre.exName3 AS 'Exercise3'
                        FROM daily_routine_conatins_exercise dre
                        JOIN plans p ON dre.planId = p.planId
                        JOIN workout_plan wp ON p.planId = wp.planId
                        WHERE p.planName = 'Weight Loss PLan';
						select*from plans
-- Insert exercises into daily routine for dayNo 1
INSERT INTO daily_routine_conatins_exercise (dayNo, planId, exName1, exName2, exName3)
VALUES (1,1, 'Running', 'Push-ups', 'Squats');

-- Insert exercises into daily routine for dayNo 2
INSERT INTO daily_routine_conatins_exercise (dayNo, planId, exName1, exName2, exName3)
VALUES (2,1, 'Deadlifts', 'Bench Press', 'Barbell Rows');

-- Insert exercises into daily routine for dayNo 3
INSERT INTO daily_routine_conatins_exercise (dayNo, planId, exName1, exName2, exName3)
VALUES (3,1, 'Walking Lunges', 'Plank', 'Dumbbell Shoulder Press');

-- Insert exercises into daily routine for dayNo 4
INSERT INTO daily_routine_conatins_exercise (dayNo, planId, exName1, exName2, exName3)
VALUES (4,1, 'Pull-ups', 'Lunges', 'Dumbbell Bicep Curls');

CREATE TABLE equiptment (
	eqName NVARCHAR(255) PRIMARY KEY,
	descr NVARCHAR(255),
	addedDate NVARCHAR(255)
)

CREATE TABLE daily_target (
	dayNo NUMERIC PRIMARY KEY,
	planId NUMERIC,
	FOREIGN KEY (planId) REFERENCES plans(planId)
)

CREATE TABLE meal (
	mealName NVARCHAR(255) PRIMARY KEY,
	descr NVARCHAR(255),
	purpose NVARCHAR(255),
	dietType NVARCHAR(255)
)
-- Inserting the first meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Breakfast', 'Scrambled eggs with avocado and whole grain toast', 'Provide energy for the day', 'Balanced diet');

-- Inserting the second meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Morning Snack', 'Greek yogurt with mixed berries and almonds', 'Provide a nutritious snack', 'Low-carb');

-- Inserting the third meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Lunch', 'Grilled chicken salad with mixed greens and balsamic vinaigrette', 'Refuel and nourish the body', 'Low-calorie');

-- Inserting the fourth meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Afternoon Snack', 'Apple slices with peanut butter', 'Provide a quick energy boost', 'Balanced diet');

-- Inserting the fifth meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Dinner', 'Baked salmon with quinoa and steamed vegetables', 'Promote muscle repair and recovery', 'High-protein');

-- Inserting the sixth meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Evening Snack', 'Carrot sticks with hummus', 'Satisfy hunger without overloading on calories', 'Low-calorie');

-- Inserting the seventh meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Pre-Workout Snack', 'Banana with almond butter', 'Provide energy for exercise', 'Balanced diet');

-- Inserting the eighth meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Post-Workout Meal', 'Protein shake with banana and spinach', 'Support muscle recovery and growth', 'High-protein');

-- Inserting the ninth meal
INSERT INTO meal (mealName, descr, purpose, dietType)
VALUES ('Bedtime Snack', 'Cottage cheese with pineapple chunks', 'Promote overnight muscle repair', 'High-protein');

CREATE TABLE food_Items (
	itemName NVARCHAR(255) PRIMARY KEY,
	fibre NVARCHAR(255),
	protein NVARCHAR(255),
	carbs NVARCHAR(255),
	fats NVARCHAR(255),
	calories NVARCHAR(255),
)

CREATE TABLE allergen (
	allName NVARCHAR(255) PRIMARY KEY
)

CREATE TABLE gym_feedback (
	gymId NUMERIC PRIMARY KEY,
	details NVARCHAR(255),
	rating NUMERIC
)
DROP TABLE requests
CREATE TABLE requests (
	reqId NUMERIC PRIMARY KEY,
	roles NVARCHAR(255),
	userId NVARCHAR(20),
	request NVARCHAR(255),
	locationn NVARCHAR(255),
	currStatus NVARCHAR(255),
	FOREIGN KEY (userId) REFERENCES users(userId)
)
INSERT INTO requests VALUES(1,'Owner', 'O4', 'Approval as Owner', ,'Pending')
SELECT R.reqId, U.userId, U.fName, R.roles, R.currStatus
                    FROM requests R
                    JOIN users U ON R.userId = U.userId