
import { Category } from "../category-models/category.model";

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
  