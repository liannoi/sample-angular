export interface ProductPhotosListViewModel {
  productPhotos: ProductPhotoModel[];
}

export interface ProductPhotoModel {
  photoId: number;
  productId: number;
  path: string;
}
