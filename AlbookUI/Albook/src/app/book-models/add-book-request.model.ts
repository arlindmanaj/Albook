import { Category } from "../categories/category-models/category.model";
import { Translation } from './../Translations/translations/translations.model';

export interface AddBookRequest {
  title: string;
  author: string;
  description: string;
  language: string;
  coverUrl: string;
  contentUrl: string;
  price: number;
  categoryIds: number[];
  translations: Translation[];
}
