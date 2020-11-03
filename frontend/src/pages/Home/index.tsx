import React, { useEffect, useState } from 'react';

import './styles.css';

import { Link, useHistory } from 'react-router-dom';
import { FaPowerOff, FaRegTrashAlt } from 'react-icons/fa';
import api from '../../services/api';

interface CustumerListResponse {
    success: boolean;
    data: CustumerList[];
}

interface CustumerList {
    id: string;
    name: string;
    email: string;
    cpfCnpj: string;
    companyName: string;
    zipCode: string;
    stage: string;
    phoneNumbers: string[];
    type: string;
}


export default function Home() {
    const [customers, setCustomers] = useState<CustumerList[]>([]);
    const history = useHistory();

    function handleLogout() {
        history.push('/');
    }

    async function handleDelete(id: string) {
        try{
            await api.delete(`/customer?id=${id}`);
            setCustomers(customers.filter(customer => customer.id !== id));
        } catch(err) {
            console.log('erro ao deletar client', err);
        }
    }

    useEffect(() => {
        
        api.get<CustumerListResponse>('/customer/list').then((response) =>{
            setCustomers(response.data.data);
        } );
        
    }, []);

    return(
        <div className="dashboard-container">
            <header>
                <button type="button" onClick={() => handleLogout()}>
                    <FaPowerOff size={18} color="#8A05BE"/>
                </button>
            </header>

            <h1>Clientes disponíveis</h1>

            <ul>

            { customers.map(customer => (
                <li key={ customer.id }>
                    <div className="card-header">
                        <button onClick={() => handleDelete(customer.id)} type="button">
                            <FaRegTrashAlt size={20} color="#a8a8b3"/>
                        </button>
                    </div>
                   <div className="info-details">
                        <span>Nome: </span>
                        <span>{customer.name}</span>

                   </div>

                   <div className="info-details">
                        <span>Empresa: </span>
                        <span>{customer.companyName}</span>
                   </div>

                   <div className="info-details">
                        <span>Cpf/Cnpj: </span>
                        <span>{customer.cpfCnpj}</span>
                   </div>
                  
                   <div className="info-details">
                        <span>Email: </span>
                        <span>{customer.email}</span>
                   </div>

                   <div className="info-details">
                        <span>Stage: </span>
                        <span>{customer.stage}</span>
                   
                   </div>

                   <div className="info-details">
                        <span>Tipo: </span>
                        <span>{customer.type}</span>
                   </div>

                  <div className="info-details">
                    <span>Telefones: </span>
                    {customer.phoneNumbers.map(phone => (
                        <span key={phone}>{phone}</span>
                    ))}
                  </div>
                </li>
            ))}
            </ul>
        </div>
    );
}