import axios from 'axios';

const api = axios.create({
    baseURL: "https://localhost:5001/custumer"
});

export default api;