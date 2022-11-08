import { useEffect, useState } from "react";
import { FetchApi } from "../api/ApiFetch";
import { ApiFetch } from "../interface/Interfaces";

export const Directories = () => {
  const [get, setGet] = useState<ApiFetch[]>([]);
  const [getPath, setGetPath] = useState<ApiFetch[]>([]);

  const GetApi = async () => {
    const api = await FetchApi.get();
    setGet(api);
  };

  const GetPath = async () => {
    const api = await FetchApi.getPath("CRUD");
    setGetPath(api);
  };

  useEffect(() => {
    GetApi();
    GetPath();
  }, []);

  const buttonFiles = () => {
    console.log(getPath)
  }

  const render = () => {
    return get.map((item , index) => {
      const dirs = item.directories.map((items , index) => {
        return(
          <p key={index}>{items}</p>
        )
      })
      return (
        <div key={index} className="bg-red-300 flex items-center flex-col gap-1">
          <h1 className="text-3xl">{item.name}</h1>
          {dirs}
        </div>
      )

    })
  }

  return <div>
    {render()}
    <button onClick={buttonFiles}>
      Preciona
    </button>
  </div>;
};
