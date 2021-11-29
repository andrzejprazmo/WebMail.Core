export interface FolderContract {
  folderName: string,
  folderType: number,
}

export interface FolderPackageContract {
  folders: FolderContract[],
}

export interface MailHeaderContract {
  index: number,
  subject: string,
  date: Date,
  sender: string,
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
}

