import React, { Component } from 'react';
import { DataGrid, Column, Editing, Scrolling, Lookup, Summary, TotalItem } from 'devextreme-react/data-grid';
import DataSource from 'devextreme/data/data_source';
import { coalitionStore } from '../../../stores/coalitionStore';

function onRowUpdating(options) {
    options.newData = {...options.oldData, ...options.newData };
    debugger;
};

export class DataGridv2 extends Component {
    constructor(props) {
        super(props);
        debugger;
        this.state = {
            columns: this.props.columns,
            rows: this.props.rows ?? [],
            grouping: this.props.grouping ?? [],
            currentPage: this.props.currentPage ?? 1,
            pageSize: this.props.pageSize ?? 10,
            dataSource: coalitionStore.store,
            refreshMode: 'reshape'
        }
    }

    dataSource = new DataSource({
        store: this.props.store,
        reshapeOnPush: true
    });

    render() {
        debugger;
        return (
            <>
                <DataGrid
                    dataSource={this.dataSource}
                    repaintChangesOnly={true}
                    showBorders={true}
                    onRowUpdating={onRowUpdating}
                >
                    <Editing
                        refreshMode={this.state.refreshMode}
                        mode="cell"
                        allowAdding={true}
                        allowDeleting={true}
                        allowUpdating={true}
                    />
                    <Scrolling
                        mode="virtual"
                    />
                </DataGrid>
            </>
        );
    }
}

export default DataGridv2;
