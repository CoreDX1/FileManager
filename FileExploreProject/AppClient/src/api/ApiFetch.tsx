import axios, { AxiosResponse } from "axios";
import { ApiFetch, ContratoApi } from "../interface/Interfaces";

class Fetch<T> implements ContratoApi<T> {
  url: string;

  constructor(url: string) {
    this.url = url;
  }

  get = async (): Promise<T[]> => {
    const { data }: AxiosResponse<T[]> = await axios.get(this.url);
    return data;
  };

  getPath = async (path: string): Promise<T[]> => {
    const { data }: AxiosResponse<T[]> = await axios.get(this.url + path);
    return data;
  };
}

export const ApiHttp = new Fetch<ApiFetch>("https://localhost:7160/api/Files/");
