SELECT mbx.mbx_id AS Id
	, mbx.mbx_domain_name AS DomainName
	, mbx.mbx_imap_address AS ImapAddress
	, mbx.mbx_imap_port AS ImapPort
	, mbx.mbx_smtp_address AS SmtpAddress
	, mbx.mbx_smtp_port AS SmtpPort
	, mbx.mbx_smtp_ssl AS SmtpSsl
	, mbx.mbx_imap_ssl AS ImapSsl
FROM mailboxes mbx
WHERE mbx.mbx_domain_name = @DomainName