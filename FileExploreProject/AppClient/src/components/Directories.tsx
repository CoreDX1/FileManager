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
    const api = await FetchApi.getPath("dir1-Test");
    setGetPath(api);
  };

  useEffect(() => {
    GetApi();
    GetPath();
  }, []);

  const renderMouse = () => {
    console.log(getPath);
  };

  const render = () => {
    return get.map((item, index) => {

      const dir = item.directory.map((x, index) => {
        return (
          <p key={index} className="cursor-pointer" onClick={renderMouse}>
            {x}
          </p>
        );
      });

      const file = item.file.map((x, index) => {
        return <p key={index}>{x}</p>;
      });
      return (
        <div key={index}>
          <div>
          </div>
          {dir}
          {file}
        </div>
      );
    });
  };

  console.log(get)
  return (
    <div>
    </div>
  );
};
