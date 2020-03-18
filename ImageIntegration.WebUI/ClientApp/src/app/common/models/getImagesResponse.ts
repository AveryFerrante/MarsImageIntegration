export interface GetImagesResponse {
  name: string;
  data: Uint8Array;
  extention: ImageFileExtention;
}

interface ImageFileExtention {
  value: string;
}
