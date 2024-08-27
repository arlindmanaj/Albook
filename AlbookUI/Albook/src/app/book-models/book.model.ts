export interface Book {
    bookId: string;
    title: string;
    author: string;
    description: string;
    language: string;
    coverUrl: string;
    contentUrl: string;
    price: number;
    publishedAt: Date;
    createdAt: Date;

    categoryName: string;
  }
  