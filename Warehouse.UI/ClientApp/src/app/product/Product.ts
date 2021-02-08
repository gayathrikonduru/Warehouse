import { ProductArticle } from "./product-article";

export class Product {
  productId: number;
  name: string;
  price: number;
  containArticles: ProductArticle[];
}
