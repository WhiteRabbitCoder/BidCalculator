import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5088/api",
});

export const calculateBid = (vehicle) =>
    api.post("/calculate", vehicle).then((res) => res.data);
