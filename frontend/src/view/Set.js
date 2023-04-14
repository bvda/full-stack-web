import { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { fetchSet } from "../service/SetService";

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
    <div>
      <h1>{set.name}</h1>
      <ul>
        {set.cards.map(c => (<li key={c.id}><Link to={`/card/${c.id}`}>{c.name}</Link></li>))}
      </ul>
    </div>
  ) : <>Loading...</>;
}