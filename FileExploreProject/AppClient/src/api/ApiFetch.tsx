import axios from "axios";

export const FetchApi = {
  get: async () => {
    const {data} = await axios.get("https://localhost:7160/api/Files")
    return data;
  },
  getPath : async (path : string) => {
    const {data} = await axios.get("https://localhost:7160/api/Files/" + path)
    return data;
  }
};