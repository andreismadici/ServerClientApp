<template>
    <div id="admin-controler">
        <HeaderAdmin />
        <form @submit.prevent>
            <button type="butonAdmin" @click="listaClienti" class="btn">Clienti</button>
            <input type="textAdmin" v-model="idClient" name = "idClient" placeholder="ID Client">
            <button type="butonAdmin" @click="listaComenzi" class="btn">Cauta Client</button>
            <input type="textAdmin" v-model="idComanda" name = "idComanda" placeholder="ID Comanda">
            <button type="butonAdmin" @click="listaPlaci" class="btn">Cauta Comanda</button>
            <input type="textAdmin" v-model="material" name = "material" placeholder="Material">
            <button type="ButonAdmin" @click="listaStoc" class="btn">Cauta Stoc</button>
            <input type="textAdmin" v-model="idComandaUpdate" name = "idComandaUpdate" placeholder="ID Comanda">
            <button type="ButonAdmin" @click="updateComanda" class="btn">Update Comanda</button>
        </form>
        <div class="divLista" v-bind:key="varClient.id" v-for="varClient in Clienti">
            <p class = "mt">ID: {{varClient.id}}</p>
            <p class = "mt">Nume: {{varClient.name}}</p>
            <p class = "mt">Email: {{varClient.email}}</p>
        </div>
        <div class="divLista" v-bind:key="varComanda.idC" v-for="varComanda in ComenziClient" @submit.prevent>
            <p class = "mt">ID Client: {{varComanda.id}}</p>
            <p class = "mt">ID Comanda: {{varComanda.idC}}</p>
            <p class = "mt">Done: {{varComanda.done}}</p>
        </div>
        <div class="divLista" v-bind:key="varComanda.idSC" v-for="varComanda in slabComanda" @submit.prevent>
            <p class = "mt">ID Placa: {{varComanda.idSC}}</p>
            <p class = "mt">ID Comanda: {{varComanda.idC}}</p>
            <p class = "mt">Lungime: {{varComanda.lungime}}</p>
            <p class = "mt">Latime: {{varComanda.latime}}</p>
            <p class = "mt">Material: {{varComanda.material}}</p>
            <p class = "mt">ID Placa Stoc: {{varComanda.idSC}}</p>
        </div>
        <div class="divLista" v-bind:key="varComanda.idSC" v-for="varComanda in stoc" @submit.prevent>
            <p class = "mt">ID Placa: {{varComanda.idSS}}</p>
            <p class = "mt">Lungime: {{varComanda.lungime}}</p>
            <p class = "mt">Latime: {{varComanda.latime}}</p>
            <p class = "mt">Material: {{varComanda.material}}</p>
            <p class = "mt">Taken: {{varComanda.taken}}</p>
        </div>
    </div>
</template>

<script>
import HeaderAdmin from '../components/layout/HeaderAdmin';
import axios from 'axios';

export default {
    name: 'Admin',
    components: {
    HeaderAdmin
    },
    data: () => ({
        idComandaUpdate: '',
        idClient: '',
        idComanda: '',
        material: '',
        Clienti: [],
        ComenziClient:[],
        slabComanda: [],
        stoc: [],
        
    }),
    methods: {
        adaugaListaClienti(list)
        {   
            this.idComandaUpdate = '';
            this.material = '';
            this.idClient= '';
            this.slabComanda = '';
            this.stoc = '';
            this.idComanda = '';
            this.ComenziClient ='';
            this.Clienti = list;
            

        },
        adaugaListaComenziClienti(list)
        {
            if(list != '')
            {
                this.ComenziClient = list;
                this.Clienti = '';
                
                this.slabComanda = '';
                this.stoc = '';
                this.idComanda = '';
                this.material = '';
            }
            else
            {
                alert("Nu sunt comenzi pentru Id-ul dat!");
            }
        },
        adaugaListaSlabComanda(list)
        {
            if(list != '')
            {
                this.ComenziClient = '';
                this.Clienti = '';
                this.slabComanda = list;
                this.idClient = '';
                this.stoc = '';
                this.idComanda = '';
                this.material = '';
                this.idComandaUpdate = '';
            }
            else
            {
                alert("Comanda nu exista!");
            }

        },
        adaugaListaStoc(list)
        {
                if(list != '')
            {
                this.ComenziClient = '';
                this.Clienti = '';
                this.slabComanda = '';
                this.idClient = '';
                this.stoc = list;
                this.idComanda = '';
                this.material = '';
                this.idComandaUpdate = '';
            }
            else
            {
                alert("Momentan stocul este gol!");
            }

        },
        listaClienti () {
            axios.get("http://localhost:5000/api/client")
            .then(res => this.adaugaListaClienti(res.data))
            .catch(err => console.log(err));
            
        },
        listaComenzi(){
            if(this.idClient != '')
                axios.get(`http://localhost:5000/api/comanda/${this.idClient}`)
                .then(res => this.adaugaListaComenziClienti(res.data));
            
        },
        listaPlaci(){
            if(this.idComanda != '')
                axios.get(`http://localhost:5000/api/allslabcomanda/${this.idComanda}`)
                .then(res => this.adaugaListaSlabComanda(res.data));
        },
        listaStoc()
        {
            if(this.material != '')
                axios.get(`http://localhost:5000/api/slabstoc/${this.material}`)
                .then(res => this.adaugaListaStoc(res.data));
        },
        updateComanda()
        {
            if(this.ComenziClient != '')
                if(this.idComandaUpdate != '')
                {
                    axios.put(`http://localhost:5000/api/comanda/${this.idComandaUpdate}`);
                    // Trimitem mail-ul -- Daca mai apuc sa fac asta


                    this.ComenziClient = '';
                    this.listaComenzi();
                    
                    
                }
            this.idComandaUpdate ='';
            
        }

    }
}
</script>

<style scoped>
*{
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
    form {
        display: flex;
        
    }

    .divLista {
        display: flex;
        flex: 10;
        padding: 5px;
        
        
    }

    input[type="textAdmin"] {
        flex: 10;
        padding: 5px;
    }

    input[type="butonAdmin"]
    {
        flex: 2;
    }
    .btn {
        display: inline-block;
        border: none;
        background: #555;
        color: #fff;
        padding: 7px 20px;
        cursor: pointer;
    }
    .mt {
        float: left;
        flex: 1;
        padding: 5px 9px;
        
    }
</style>
