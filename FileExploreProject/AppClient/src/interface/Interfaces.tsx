export type ApiFetch = {
  name: string;
  files: any[];
  directories: string[];
}

export interface ContratoApi<T> {
   get: () => Promise<T[]>
   getPath: (path: string) => Promise<T[]>;
}
