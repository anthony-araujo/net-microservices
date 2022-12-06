export interface IBlog {
  id?: number;
  name?: string;
  handle?: string;
}

export class Blog implements IBlog {
  constructor(
    public id?: number,
    public name?: string,
    public handle?: string
  ) {}
}

export function getBlogIdentifier(blog: IBlog): number | undefined {
  return blog.id;
}
