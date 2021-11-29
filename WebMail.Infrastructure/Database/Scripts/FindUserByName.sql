SELECT usr.usr_id AS Id
	, usr.usr_name AS UserName
	, usr.usr_admin AS IsAdmin
	, usr.mbx_id AS MailboxId
FROM users usr
WHERE usr.usr_name = @UserName;

