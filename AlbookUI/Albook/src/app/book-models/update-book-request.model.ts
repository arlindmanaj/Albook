import { Category } from "../categories/category.service";

export interface UpdateBookRequest {
    title: string;
    author: string;
    description: string;
    language: string;
    coverUrl: string;
    contentUrl: string;
    price: number;
    categories: Category[];
  }
  