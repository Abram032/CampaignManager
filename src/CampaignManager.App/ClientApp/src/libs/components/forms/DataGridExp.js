import React, { Component } from 'react';
import { 
    DataGrid, 
    Column, 
    Editing, 
    Scrolling, 
    Lookup, 
    Summary, 
    TotalItem, 
    Paging, 
    Pager, 
    Grouping, 
    GroupPanel,
    FilterRow,
    HeaderFilter,
    SearchPanel,
    ColumnChooser, 
    ColumnFixing,
    MasterDetail
} from 'devextreme-react/data-grid';
import DataSource from 'devextreme/data/data_source';

function onRowUpdating(options) {
    options.newData = {...options.oldData, ...options.newData };
};

export class DataGridExp extends Component {
    constructor(props) {
        super(props);
        this.state = {
            refreshMode: 'reshape',
            autoExpandAll: false,
            showFilterRow: true,
            showHeaderFilter: true,
            currentFilter: 'auto'
        }
    }

    dataSource = new DataSource({
        store: this.props.store,
        reshapeOnPush: true
    });

    render() {
        return (
            <>
                <DataGrid
                    dataSource={this.dataSource}
                    repaintChangesOnly={true}
                    showBorders={true}
                    showColumnLines={true}
                    showRowLines={true}
                    rowAlternationEnabled={true}
                    onRowUpdating={onRowUpdating}
                    allowColumnReordering={true}
                    allowColumnResizing={true}
                    columnAutoWidth={true}
                >
                    <Editing
                        refreshMode={this.state.refreshMode}
                        mode="form"
                        allowAdding={true}
                        allowDeleting={true}
                        allowUpdating={true}
                    />
                    <ColumnChooser enabled={true} />
                    <ColumnFixing enabled={true} />
                    <FilterRow visible={this.state.showFilterRow}
                        applyFilter={this.state.currentFilter} />
                    <HeaderFilter visible={this.state.showHeaderFilter} />
                    <SearchPanel visible={true}
                        width={240}
                        placeholder="Search..." />
                    <GroupPanel visible={true} />
                    <Grouping autoExpandAll={this.state.autoExpandAll} />
                    <Paging defaultPageSize={10} />
                    <Pager
                        showPageSizeSelector={true}
                        allowedPageSizes={[1, 2, 3, 5, 10, 25, 50]}
                        showInfo={true} 
                    />
                    <MasterDetail 
                        enabled={true}
                        component={this.props.detailComponent}
                    />
                    {this.props.columns}
                </DataGrid>
            </>
        );
    }
}

export default DataGridExp;
