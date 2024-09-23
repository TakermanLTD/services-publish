<template>
    <div class="row">
        <div class="table-responsive">
            <table class="table table">
                <thead>
                    <tr class="table-primary">
                        <th></th>
                        <th>
                            <label for="project" class="form-label">Project</label>
                            <input type="text" class="form-control" id="project" placeholder="Project" v-model="this.projectName" />
                        </th>
                        <th>
                            <button @click="add" type="button" class="btn btn-success">
                                <i class="fa-solid fa-plus"></i>
                            </button>
                        </th>
                    </tr>
                    <tr class="table-primary">
                        <th scope="col">Id</th>
                        <th scope="col">Name</th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(project, index) in this.projects" :key="index">
                        <td scope="row">{{ project.id }}</td>
                        <td>{{ project.name }}</td>
                        <td>
                            <button @click="this.delete(project.id)" type="button" class="btn btn-danger">
                                <i class="fa-solid fa-minus"></i>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            projects: [],
            projectName: ''
        }
    },
    async mounted() {
        await this.refresh();
    },
    methods: {
        async refresh() {
            this.projects = await (await fetch('/Projects/GetAll')).json();
        },
        async add() {
            let newProject = await (await fetch('/Projects/Create', {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ name: this.projectName })
            })).json();
            this.projectName = '';
            await this.refresh();
        },
        async delete(id) {
            if (confirm('Do you want to delete it for sure?')) {
                let removed = await (await fetch('/Projects/Delete?id=' + id, {
                    method: "DELETE"
                })).json();
                await this.refresh();
            }
        }
    },
}
</script>