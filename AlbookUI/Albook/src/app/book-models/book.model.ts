import { Category } from "../categories/category.service";
import { Translation } from "../Translations/translations/translations.model";

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
  translations: Translation[];

  categories: Category[];
}
