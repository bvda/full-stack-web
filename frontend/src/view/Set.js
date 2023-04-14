import { useState, useEffect } from "react";
import {useParams } from "react-router-dom";
import { fetchSet } from "../service/SetService";
import { CardList } from "./CardList";

export function SetView() {
  const { id } = useParams();
  const [set, setSet] = useState();

  useEffect(() => {
    const getSet = async () => {
      try {
        const data = await fetchSet(id);
        setSet(data);
      } catch (error) {
        console.error(error);
      }
    };

    getSet();
  }, [id]);

  return set ? (
    <>
      <h1>{set.name}</h1>
      <CardList items={set.cards} />
    </>
  ) : <>Loading...</>;
}