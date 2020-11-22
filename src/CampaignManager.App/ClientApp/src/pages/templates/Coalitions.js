import React, { Component } from 'react';
import DataGrid from '../../libs/components/forms/DataGrid';
import DataGridv2 from '../../libs/components/forms/DataGridv2';
import { coalitionStore } from '../../stores/coalitionStore';

const apiUri = `${window.location.origin}/api/coalition`;
const columns = [
  { name: 'id', title: 'Id' },
  { name: 'name', title: 'Name' },
  { name: 'color', title: 'Color' },
];

export class Coalitions extends Component {
  constructor(props) {
    super(props);
  };

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
      <>
        <DataGrid columns={columns} rowDetail={this.rowDetail} apiUri={apiUri} />
        <DataGridv2 columns={columns} rowDetail={this.rowDetail} apiUri={apiUri} store={coalitionStore}/>
      </>
    );
  }
};

export default Coalitions;