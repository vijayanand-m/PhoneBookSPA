import React, { Component } from 'react';
import { AgGridColumn, AgGridReact } from 'ag-grid-react';
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-balham.css";

export class PhoneBook extends Component {
    static displayName = PhoneBook.name;
   
    constructor(props) {
        super(props);
        this.state = {
            phonebook: [],
            loading: true,
           };
        
    }

    componentDidMount() {
        this.populateContactsData();
    }

    render() {
       
        const onGridReady = (params) => {
            params.api.sizeColumnsToFit();
        };
        return (
            <div className="ag-theme-balham" style={{ height:350,width:900 }}>
                <AgGridReact
                    rowData={this.state.phonebook.contacts}
                    defaultColDef={{
                        sortable: true,
                        filter: true,
             
                        headerComponentParams: {
                            menuIcon: 'fa-bars'
                        }
                    } }
                 onGridReady={onGridReady}>
                    <AgGridColumn field="name" sortable={true} filter={true} resizable={true} ></AgGridColumn>
                    <AgGridColumn field="phone_number" sortable={true} filter={true} resizable={true}></AgGridColumn>
                    <AgGridColumn field="address" sortable={true} filter={true} resizable={true} wrapText={true}></AgGridColumn>
                </AgGridReact>
            </div>
            );
    }

    async populateContactsData() {
        const response = await fetch('PhoneBook');
        const data = await response.json();
        this.setState({ phonebook: data, loading: false });
    }
}