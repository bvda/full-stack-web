import { useState, useEffect } from "react";
import { fetchSets } from "../service/SetService";
import { Link } from "react-router-dom";

export function SetsView() {
  const [sets, setSets] = useState([]);

  useEffect(() => {
    const getSets = async () => {
      try {
        const data = await fetchSets();
        setSets(data);
      } catch (error) {
        console.error(error);
      }
    };

    getSets();
  }, []);

  return (
    <div>
      <h1>Sets</h1>
      <ul>
        {sets.map((s) => (
          <li key={s.name}><Link to={`${s.id}`}>{s.name}</Link></li>
        ))}
      </ul>
    </div>
  );
}