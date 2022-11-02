import { useEffect, useState } from "react";
import { FetchApi } from "../api/ApiFetch";

interface ApiFetch {
  name: string;
  directories: Array<string>;
  files: Array<string>;
}
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
    console.log(getPath)
  }

  const render = () => {
    return get.map((item, index) => {
      const dir = item.directories.map((x, index) => {
        return (
          <p key={index} className="cursor-pointer">
            {x}
          </p>
        );
      });

      const file = item.files.map((x, index) => {
        return <p key={index}>{x}</p>;
      });
      return (
        <div key={index}>
          <div>
            <p>{item.name}</p>
          </div>
          {dir}
          {file}
        </div>
      );
    });
  };

  console.log(getPath);

  return <div>
    {render()}
    <div>
      <button onClick={renderMouse} className="bg-red-800 font-bold">Button</button>
    </div>
    </div>;
};
