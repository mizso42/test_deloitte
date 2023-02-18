-- Task 1
SELECT Login, Name, MAX(LastLogin, User_B.LoginDate) as [Last known login]
	from User_A JOIN User_B
    	on User_A.Login = User_B.Login_ID
    GROUP by login
;

-- Task 2
SELECT Login, Name, MAX(lastlogin) AS [Last known login]
	FROM User_A
    	WHERE login not in (
          SELECT login_id from User_B
        )
    GROUP BY login
UNION
SELECT login_id, full_name, MAX(logindate)
	FROM User_B
    	WHERE login_id not in (
          SELECT login from User_A
        )
    GROUP BY login_id
