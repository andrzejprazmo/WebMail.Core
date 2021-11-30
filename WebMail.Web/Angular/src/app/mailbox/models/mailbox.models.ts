export interface FolderContract {
  folderName: string,
  folderType: number,
  displayName: string,
}

export interface FolderPackageContract {
  folders: FolderContract[],
}

export interface MailAddress {
  name: string,
  address: string
}

export interface MailHeaderContract {
  index: number,
  subject: string,
  date: Date,
  senders: MailAddress[],
  hasAttachments: boolean,
  flagged: boolean,
  seen: boolean,
}

export 
  interface MailPackageContract {
  totalCount: number;
  pageSize: number;
  list: MailHeaderContract[],
}

export 
  interface MailBodyContract extends MailHeaderContract {
  content: string;
  recipients: MailAddress[],
}

