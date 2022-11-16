import { MouseEvent, useEffect, useState } from "react";
import { ApiHttp } from "../api/ApiFetch";
import { ApiFetch } from "../interface/Interfaces";

export const Directories = () => {
  
  const [get, setGet] = useState<ApiFetch[]>([]);
  const [getPath, setGetPath] = useState<ApiFetch[]>([]);

  const GetApi = async (): Promise<void> => {
    const api = await ApiHttp.get();
    setGet(api);
  };

  const GetPath = async (dir: string): Promise<void> => {
    const data = await ApiHttp.getPath(dir);
    setGetPath(data);
  };

  function buttonFiles(e: MouseEvent<HTMLParagraphElement>) {
    const value = e.currentTarget.textContent as string;
    GetPath(value);
    console.log(getPath);
  }

  useEffect(() => {
    GetApi();
    buttonFiles;
  }, []);

  const render = () => {
    return get.map((item, index) => {
      const dirs = item.directories.map((items, index) => {
        return (
          <p key={index} onClick={buttonFiles}>
            {items}
          </p>
        );
      });
      return (
        <div
          key={index}
          className="bg-red-300 flex items-center flex-col gap-1"
        >
          <h1 className="text-3xl">{item.name}</h1>
          {dirs}
        </div>
      );
    });
  };

  return <div>{render()}</div>;
};
