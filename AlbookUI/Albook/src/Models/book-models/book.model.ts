import { Category } from "../category-models/category.model";
import { Translation } from "../../app/Translations/translations/translations.model";

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
