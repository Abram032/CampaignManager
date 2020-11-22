import React, { Component } from 'react';
import DataGrid from '../../libs/components/forms/DataGrid';

export class Categories extends Component {
  constructor(props) {
    super(props);

    this.state = { 
      columns: [
        { name: 'id', title: 'Id' },
        { name: 'name', title: 'Name' },
        { name: 'type', title: 'Type' },
      ],
      rows: [
        { id: '1', name: 'Air-Superiority Fighter', type: 'Fighter' },
        { id: '2', name: 'Attack Aircraft', type: 'Attack' },
        { id: '3', name: 'Reconissance Aircraft', type: 'Fighter' },
        { id: '4', name: 'Multi-role Aircraft', type: 'Fighter' }
      ]
    }
  }

  rowDetail = ({ row }) => (
    <div>
      Details for
      {' '}
      {row.id}
      {' - '}
      {row.name}
      {' of type '}
      {row.type}
    </div>
  );

  render() {
    return (
        <DataGrid columns={this.state.columns} rows={this.state.rows} rowDetail={this.rowDetail}/>
      );
  }
};

export default Categories;