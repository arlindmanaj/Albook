import { Category } from "../categories/category.service";
import { Translation } from './../Translations/translations/translations.model';

export interface AddBookRequest {
    title: string;
    author: string;
    description: string;
    language: string;
    coverUrl: string;
    contentUrl: string;
    price: number;
    categories: Category[];
    translations: Translation[];
  }
  